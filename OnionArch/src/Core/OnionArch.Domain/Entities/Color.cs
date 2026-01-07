using OnionArch.Domain.Entities.Common;

namespace OnionArch.Domain.Entities;

public class Color:BaseEntity
{
    public string Name { get; set; } = null!;
    public List<ProductColor> ProductColors { get; set; } = new();
}
