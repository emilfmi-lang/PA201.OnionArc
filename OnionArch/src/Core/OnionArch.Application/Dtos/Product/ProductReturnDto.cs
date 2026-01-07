
using FluentValidation;
using OnionArch.Domain.Enums;

namespace OnionArch.Application.Dtos.Product;

public record ProductReturnDto(string Name, decimal Price, string CategoryName,string ProductStatusName);


