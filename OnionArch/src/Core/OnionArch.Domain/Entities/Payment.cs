using OnionArch.Domain.Entities.Common;

namespace OnionArch.Domain.Entities;

public class Payment : BaseEntity
{
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = null!;
    public Order Order { get; set; } = null!;
}
