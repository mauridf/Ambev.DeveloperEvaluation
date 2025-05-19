namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleDto
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<SaleItemDto> Items { get; set; }
    }

    public class SaleItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}