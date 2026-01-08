
using OnionArch.Domain.Entities.Common;
using OnionArch.Domain.Enums;

namespace OnionArch.Domain.Entities;

public class Product:BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ProductStatus Status { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<ProductColor> ProductColors { get; set; } = new();
    public string ImageFile { get; set; } = null!;
}
