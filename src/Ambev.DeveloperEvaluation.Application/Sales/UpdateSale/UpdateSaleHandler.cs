using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResponse> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.SaleId);

        if (sale == null)
        {
            throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found.");
        }

        // Map data from command to entity
        sale.Client = request.CustomerName;
        sale.SaleDate = request.SaleDate;

        // Update SaleItems
        foreach (var item in request.SaleItems)
        {
            var saleItem = sale.Items.FirstOrDefault(si => si.Id == item.SaleItemId);
            if (saleItem != null)
            {
                saleItem.Quantity = item.Quantity;
                saleItem.UnitPrice = item.Price;
            }
        }

        await _saleRepository.UpdateAsync(sale);

        return new UpdateSaleResponse
        {
            Success = true,
            Message = "Sale updated successfully",
            UpdatedSale = _mapper.Map<SaleDto>(sale)
        };
    }
}
