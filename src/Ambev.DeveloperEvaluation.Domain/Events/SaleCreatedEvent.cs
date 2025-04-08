using System;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCreatedEvent : IDomainEvent
{
    public Guid SaleId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public SaleCreatedEvent(Guid saleId)
    {
        SaleId = saleId;
        Console.WriteLine($"[EVENT] SaleCreatedEvent triggered for sale: {SaleId}");
    }
}
