namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        public Guid SaleId { get; set; }
        public decimal NewTotalAmount { get; set; }
        public int ItemsCount { get; set; }
    }
}