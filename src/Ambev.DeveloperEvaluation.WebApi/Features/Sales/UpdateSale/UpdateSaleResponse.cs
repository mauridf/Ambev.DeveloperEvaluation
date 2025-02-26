namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

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
}
