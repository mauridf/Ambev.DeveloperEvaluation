namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesResponse
{
    public List<GetSaleResponse> Sales { get; set; } = new List<GetSaleResponse>();
}

public class GetSaleResponse
{
    /// <summary>
    /// The unique identifier of the get sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale's number
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// The sale date
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The client's name for the sale
    /// </summary>
    public string Client { get; set; } = string.Empty;

    /// <summary>
    /// The branch from where the sale occurred
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The items in the sale
    /// </summary>
    public List<GetSaleItemResponse> Items { get; set; } = new();
}

public class GetSaleItemResponse
{
    public string Product { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
