using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Response model for GetSale operation
    /// </summary>
    public class GetSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The ID of the client for the sale
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// The total amount for the sale
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The date and time when the sale occurred
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The status of the sale (using IsCancelled flag)
        /// </summary>
        public string Status { get; set; } // Usando string para o status

        /// <summary>
        /// The items involved in the sale
        /// </summary>
        public List<SaleItem> Items { get; set; }

        public GetSaleResult(Sale sale)
        {
            Id = sale.Id;
            Client = sale.Client;
            TotalAmount = sale.TotalAmount;
            SaleDate = sale.SaleDate;
            Items = sale.Items;
            // Determinando o status baseado em IsCancelled
            Status = sale.IsCancelled ? "Cancelled" : "Completed";
        }
    }
}
