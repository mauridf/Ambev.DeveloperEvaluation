namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public string BranchName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public IEnumerable<SaleItemResponse> Items { get; set; }

        public class SaleItemResponse
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalItem { get; set; }
        }
    }
}