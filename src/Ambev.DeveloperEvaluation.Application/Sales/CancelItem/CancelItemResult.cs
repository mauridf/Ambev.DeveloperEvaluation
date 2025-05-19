namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem
{
    public class CancelItemResult
    {
        public Guid SaleId { get; set; }
        public Guid ItemId { get; set; }
        public bool Success { get; set; }
        public decimal NewTotalAmount { get; set; }
    }
}