using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleItemDto(string ProductName, int Quantity, decimal UnitPrice);

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    [Required]
    public Guid UserId { get; init; }
    public List<CreateSaleItemDto> Items { get; init; } = new();
}
