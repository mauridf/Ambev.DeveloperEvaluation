using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;

public class Sale : IHasDomainEvents
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public SaleStatus Status { get; private set; }

    public virtual User User { get; set; }

    private readonly List<SaleItem> _items = new();
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    public Sale(Guid customer)
    {
        Id = Guid.NewGuid();
        UserId = customer;
        Status = SaleStatus.Created;
        TotalAmount = 0;
        _domainEvents.Add(new SaleCreatedEvent(Id));
    }

    public void AddItem(string productName, int quantity, decimal unitPrice)
    {
        if (Status == SaleStatus.Cancelled)
            throw new InvalidOperationException("Cannot add item to a cancelled sale.");

        if (quantity < 1)
            throw new InvalidOperationException("Quantity must be greater than zero.");

        if (quantity < 4)
        {
            // No discount
        }
        else if (quantity >= 4 && quantity < 10)
        {
            unitPrice *= 0.9m; // 10% discount
        }
        else if (quantity >= 10 && quantity <= 20)
        {
            unitPrice *= 0.8m; // 20% discount
        }
        else
        {
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");
        }

        var item = new SaleItem
        {
            SaleId = Id,
            ProductName = productName,
            Quantity = quantity,
            UnitPrice = unitPrice
        };

        _items.Add(item);
        RecalculateTotal();
    }

    public void RemoveItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null)
            throw new InvalidOperationException("Item not found.");

        _items.Remove(item);
        RecalculateTotal();
    }

    public void CancelItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null)
            throw new InvalidOperationException("Item not found.");

        item.Cancel(); // vamos definir abaixo
        _domainEvents.Add(new ItemCancelledEvent(item.Id));
        RecalculateTotal();
    }

    public void ClearItems()
    {
        _items.Clear();
        RecalculateTotal();
    }

    public void ModifyCustomer(Guid customer)
    {
        UserId = customer;
        _domainEvents.Add(new SaleModifiedEvent(Id));
    }

    public void Cancel()
    {
        if (Status == SaleStatus.Cancelled)
            return;

        Status = SaleStatus.Cancelled;
        _domainEvents.Add(new SaleCancelledEvent(Id));
    }

    private void RecalculateTotal()
    {
        TotalAmount = _items.Where(i => !i.IsCancelled).Sum(i => i.Total);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected Sale() { }

}
