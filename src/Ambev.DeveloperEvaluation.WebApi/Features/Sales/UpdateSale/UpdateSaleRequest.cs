using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequest
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime SaleDate { get; set; }
    public List<UpdateSaleItemRequest> SaleItems { get; set; }
}

public class UpdateSaleItemRequest
{
    public Guid SaleItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
