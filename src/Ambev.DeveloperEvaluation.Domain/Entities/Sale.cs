namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Client { get; set; }
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new();
        public bool IsCancelled { get; set; }

        public void CancelSale()
        {
            IsCancelled = true;
            foreach (var item in Items)
            {
                item.CancelItem();
            }
        }

        public void RecalculateTotal()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                TotalAmount += item.TotalPrice;
            }
        }
    }
}
