using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesResponse
{
    public List<GetSalesItemDto> Sales { get; set; } = new();
}

public class GetSalesItemDto
{
    public Guid Id { get; set; }
    public decimal TotalAmount { get; set; }
}