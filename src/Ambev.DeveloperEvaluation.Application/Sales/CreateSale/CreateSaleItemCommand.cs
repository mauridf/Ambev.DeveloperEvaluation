using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Command to create a sale item.
    /// </summary>
    public class CreateSaleItemCommand : IRequest
    {
        public Guid SaleId { get; set; }
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public CreateSaleItemCommand(Guid saleId, string product, int quantity, decimal unitPrice, decimal discount)
        {
            SaleId = saleId;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }
    }
}
