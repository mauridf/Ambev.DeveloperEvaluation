using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public string CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string BranchId { get; private set; }
        public string BranchName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public SaleStatus Status { get; private set; }
        public ICollection<SaleItem> Items { get; private set; } = new List<SaleItem>();

        protected Sale() { }

        public Sale(int saleNumber, DateTime saleDate, string customerId, string customerName,
                   string branchId, string branchName)
        {
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            Status = SaleStatus.NotCancelled;
        }

        public void AddItem(SaleItem item)
        {
            if (Status == SaleStatus.Cancelled)
                throw new DomainException("Cannot add items to a cancelled sale");

            if (item.Quantity > 20)
                throw new DomainException("Cannot sell more than 20 units of the same product");

            Items.Add(item);
            CalculateTotal();
        }

        public void RemoveItem(Guid itemId)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                Items.Remove(item);
                CalculateTotal();
            }
        }

        public void CancelItem(Guid itemId)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.Cancel();
                CalculateTotal();
            }
        }

        public void CancelSale()
        {
            Status = SaleStatus.Cancelled;
            foreach (var item in Items)
            {
                item.Cancel();
            }
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            TotalAmount = Items.Where(i => !i.IsCancelled).Sum(i => i.TotalItem);
        }
    }
}