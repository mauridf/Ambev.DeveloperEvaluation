using System;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class ItemCancelledEvent : IDomainEvent
{
    public Guid SaleItemId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public ItemCancelledEvent(Guid saleItemId)
    {
        SaleItemId = saleItemId;
        Console.WriteLine($"[EVENT] ItemCancelledEvent triggered for sale: {SaleItemId}");
    }
}
