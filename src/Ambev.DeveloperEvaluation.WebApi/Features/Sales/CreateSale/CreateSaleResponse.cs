namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale
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
        public List<CreateSaleItemResponse> Items { get; set; } = new();
    }

    public class CreateSaleItemResponse
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
