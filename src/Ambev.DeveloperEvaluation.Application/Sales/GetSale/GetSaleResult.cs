﻿using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        public Guid Id { get; set; }
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleStatus Status { get; set; }
        public IEnumerable<SaleItemResult> Items { get; set; }

        public class SaleItemResult
        {
            public Guid Id { get; set; }
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal DiscountApplied { get; set; }
            public decimal TotalItem { get; set; }
            public bool IsCancelled { get; set; }
        }
    }
}