using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        public SaleService(ISaleRepository saleRepository, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            await _saleRepository.AddAsync(sale);
            return sale;
        }

        public async Task<Sale> UpdateSaleAsync(Sale sale)
        {
            await _saleRepository.UpdateAsync(sale);
            await _mediator.Publish(new SaleModifiedEvent(sale));
            return sale;
        }

        public async Task<bool> CancelSaleAsync(Guid saleId)
        {
            var sale = await _saleRepository.GetByIdAsync(saleId);
            if (sale == null) return false;

            sale.CancelSale();
            await _saleRepository.UpdateAsync(sale);
            await _mediator.Publish(new SaleCancelledEvent(sale));
            return true;
        }

        public async Task<bool> CancelSaleItemAsync(Guid saleId, Guid itemId)
        {
            var sale = await _saleRepository.GetByIdAsync(saleId);
            if (sale == null) return false;

            var item = sale.Items.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return false;

            sale.CancelItem(itemId);
            await _saleRepository.UpdateAsync(sale);
            await _mediator.Publish(new ItemCancelledEvent(sale, item));
            return true;
        }
    }
}