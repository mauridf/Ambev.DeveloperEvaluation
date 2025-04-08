using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, Unit>
{
    private readonly ISaleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSaleHandler(ISaleRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.Id);

        if (sale is null)
            throw new KeyNotFoundException("Sale not found.");

        await _repository.DeleteAsync(sale);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}
