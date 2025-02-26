using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SaleId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCancelled { get; set; }

        public void ApplyDiscount()
        {
            if (Quantity < 4)
                Discount = 0;
            else if (Quantity >= 4 && Quantity < 10)
                Discount = 0.10m;
            else if (Quantity >= 10 && Quantity <= 20)
                Discount = 0.20m;
            else
                throw new InvalidOperationException("Quantity greater than 20 is not allowed.");

            TotalPrice = (UnitPrice * Quantity) * (1 - Discount);
        }

        public void CancelItem()
        {
            IsCancelled = true;
            TotalPrice = 0;
        }
    }
}
