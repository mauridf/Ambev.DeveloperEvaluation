namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResult
    {
        public Guid SaleId { get; set; }
        public decimal NewTotalAmount { get; set; }
        public int ItemsCount { get; set; }
    }
}