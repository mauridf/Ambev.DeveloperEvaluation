using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler to process the DeleteSaleCommand
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// DeleteSaleHandler constructor
    /// </summary>
    /// <param name="saleRepository">Sales repository</param>
    public DeleteSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Process the DeleteSaleCommand
    /// </summary>
    /// <param name="request">Command to delete a sale</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Response indicating success or failure of deletion</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(request.Id);
        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        await _saleRepository.DeleteAsync(request.Id); // Agora apenas executamos a exclusão

        return new DeleteSaleResponse { Success = true };
    }
}
