using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> UpdateSaleAsync(Sale sale);
        Task<bool> CancelSaleAsync(Guid saleId);
        Task<bool> CancelSaleItemAsync(Guid saleId, Guid itemId);
    }
}