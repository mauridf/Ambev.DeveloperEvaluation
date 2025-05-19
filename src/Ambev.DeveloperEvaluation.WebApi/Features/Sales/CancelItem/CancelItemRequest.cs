using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelItem
{
    public class CancelItemRequest
    {
        public Guid SaleId { get; set; }
        public Guid ItemId { get; set; }
    }

    public class CancelItemRequestValidator : AbstractValidator<CancelItemRequest>
    {
        public CancelItemRequestValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty();
            RuleFor(x => x.ItemId).NotEmpty();
        }
    }
}