namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public SaleDto UpdatedSale { get; set; }
}

public class SaleDto
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleItemDto> SaleItems { get; set; }
}

public class SaleItemDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
