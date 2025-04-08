using System;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCancelledEvent : IDomainEvent
{
    public Guid SaleId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public SaleCancelledEvent(Guid saleId)
    {
        SaleId = saleId;
        Console.WriteLine($"[EVENT] SaleCancelledEvent triggered for sale: {SaleId}");
    }
}
