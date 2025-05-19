using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal DiscountApplied { get; private set; }
        public decimal TotalItem { get; private set; }
        public bool IsCancelled { get; private set; }

        protected SaleItem() { }

        public SaleItem(string productId, string productName, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            IsCancelled = false;

            CalculateDiscounts();
        }

        public void Cancel()
        {
            IsCancelled = true;
            TotalItem = 0;
        }

        private void CalculateDiscounts()
        {
            if (Quantity < 4)
            {
                DiscountApplied = 0;
            }
            else if (Quantity >= 4 && Quantity < 10)
            {
                DiscountApplied = UnitPrice * Quantity * 0.1m;
            }
            else if (Quantity >= 10 && Quantity <= 20)
            {
                DiscountApplied = UnitPrice * Quantity * 0.2m;
            }

            TotalItem = (UnitPrice * Quantity) - DiscountApplied;
        }
    }
}