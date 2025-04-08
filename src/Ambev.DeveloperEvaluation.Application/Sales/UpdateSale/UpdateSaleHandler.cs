using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.Id);

        if (sale is null)
            throw new KeyNotFoundException("Sale not found.");

        // Atualizar cliente
        sale.ModifyCustomer(request.UserId);

        // Atualizar os itens (recriar)
        sale.ClearItems();
        foreach (var item in request.Items)
        {
            sale.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
        }

        await _repository.UpdateAsync(sale);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<UpdateSaleResult>(sale);
    }
}
