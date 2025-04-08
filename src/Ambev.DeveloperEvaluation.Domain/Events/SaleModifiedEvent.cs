using System;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent : IDomainEvent
{
    public Guid SaleId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public SaleModifiedEvent(Guid saleId)
    {
        SaleId = saleId;
        Console.WriteLine($"[EVENT] SaleModifiedEvent triggered for sale: {SaleId}");
    }
}
