namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// The sale's unique number
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
        /// The sale items
        /// </summary>
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }

    /// <summary>
    /// Represents a sale item request to create a new sale item
    /// </summary>
    public class CreateSaleItemRequest
    {
        /// <summary>
        /// The product name for the sale item
        /// </summary>
        public string Product { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the product in the sale item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
