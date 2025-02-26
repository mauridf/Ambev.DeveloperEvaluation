using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Response model for GetAllSales operation
    /// </summary>
    public class GetAllSalesResult
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
        /// The status of the sale
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The items involved in the sale
        /// </summary>
        public List<SaleItem> Items { get; set; }

        // Construtor para mapear uma Sale para GetAllSalesResult
        public GetAllSalesResult(Sale sale)
        {
            Id = sale.Id;
            Client = sale.Client;
            TotalAmount = sale.TotalAmount;
            SaleDate = sale.SaleDate;
            Items = sale.Items;

            // Definindo o status com base na propriedade IsCancelled
            Status = sale.IsCancelled ? "Cancelled" : "Completed";
        }
    }
}
