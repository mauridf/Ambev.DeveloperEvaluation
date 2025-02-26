using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command to delete a sale
/// </summary>
public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    /// <summary>
    /// Unique identifier of the sale to be deleted
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// DeleteSaleCommand constructor
    /// </summary>
    /// <param name="id">The ID of the sale to be deleted</param>
    public DeleteSaleCommand(Guid id)
    {
        Id = id;
    }
}
