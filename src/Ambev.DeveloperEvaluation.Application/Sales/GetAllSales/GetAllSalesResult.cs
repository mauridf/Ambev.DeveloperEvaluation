using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesResult
    {
        public IEnumerable<GetSaleResult> Sales { get; set; }
        public int TotalCount { get; set; }
    }
}