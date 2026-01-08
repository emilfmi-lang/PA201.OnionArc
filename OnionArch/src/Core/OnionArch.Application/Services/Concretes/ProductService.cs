using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Dtos.Product;
using OnionArch.Application.Interfaces;
using OnionArch.Application.Models;
using OnionArch.Application.Services.Interfaces;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Services.Concretes;

public class ProductService(IApplicationDbContext dbContext, IMapper mapper,
    IValidator<ProductCreateDto> validator
    ) : IProductService
{
    public async Task<ResponseModel<ProductReturnDto>> CreateProductAsync(ProductCreateDto productCreateDto)
    {
        if (await dbContext.Products.AnyAsync(p => p.Name == productCreateDto.Name))
            throw new Exception("Product with the same name already exists.");
        var validationResult = await validator.ValidateAsync(productCreateDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return ResponseModel<ProductReturnDto>.Failure(errors);
        }
        var product = mapper.Map<Product>(productCreateDto);
        if (productCreateDto.ImageFile != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productCreateDto.ImageFile.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", "products");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fullPath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await productCreateDto.ImageFile.CopyToAsync(stream);
            }
            product.ImageFile = fileName;
        }
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
        var productDto = mapper.Map<ProductReturnDto>(product);
        return ResponseModel<ProductReturnDto>.Success(productDto);

    }

    public async Task<ResponseModel<bool>> DeleteProductAsync(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            return ResponseModel<bool>.Failure("Product not found.");
        }
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
        return ResponseModel<bool>.Success(true);
    }

    public async Task<ResponseModel<List<ProductReturnDto>>> GetAllProductsAsync()
    {
        var products = await dbContext.Products
            .ProjectTo<ProductReturnDto>(mapper.ConfigurationProvider).ToListAsync();
        return ResponseModel<List<ProductReturnDto>>.Success(products);
    }

    public async Task<ResponseModel<ProductReturnDto>> ProductGetByIdAsync(int id)
    {
        var product = await dbContext.Products
                                     .Include(p => p.Category)    
                                     .FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return ResponseModel<ProductReturnDto>.Failure("Product not found.");
        }
        var productDto = mapper.Map<ProductReturnDto>(product);
        return ResponseModel<ProductReturnDto>.Success(productDto);
    }

    public async Task<ResponseModel<bool>> UpdateProductAsync(int id, ProductCreateDto productCreateDto)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            return ResponseModel<bool>.Failure("Product not found.");
        }

        var validationResult = await validator.ValidateAsync(productCreateDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return ResponseModel<bool>.Failure(errors);
        }
        if (await dbContext.Products.AnyAsync(p => p.Name == productCreateDto.Name && p.Id != id))
            return ResponseModel<bool>.Failure("Another product with the same name already exists.");

        mapper.Map(productCreateDto, product);
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
        return ResponseModel<bool>.Success(true);
    }
}
