using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale(request.UserId);

        foreach (var item in request.Items)
        {
            sale.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
        }

        await _repository.AddAsync(sale);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<CreateSaleResult>(sale);
    }
}