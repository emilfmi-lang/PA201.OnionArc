using OnionArch.Domain.Entities.Common;

namespace OnionArch.Domain.Entities;

public class Size : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = [];
}
