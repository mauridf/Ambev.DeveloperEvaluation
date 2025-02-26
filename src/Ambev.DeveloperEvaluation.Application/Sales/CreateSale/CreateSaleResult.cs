namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Result of creating the sale.
/// </summary>
public class CreateSaleResult
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalValue { get; set; }
}
