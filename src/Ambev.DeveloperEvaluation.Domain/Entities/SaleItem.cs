using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }

    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public bool IsCancelled { get; private set; } = false;

    public virtual Sale Sale { get; set; }

    public decimal Total => Quantity * UnitPrice;

    public void Cancel()
    {
        IsCancelled = true;
    }
}
