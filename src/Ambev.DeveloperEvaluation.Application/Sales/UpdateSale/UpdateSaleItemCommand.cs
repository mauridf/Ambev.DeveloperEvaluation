namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleItemCommand
{
    public Guid SaleItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
