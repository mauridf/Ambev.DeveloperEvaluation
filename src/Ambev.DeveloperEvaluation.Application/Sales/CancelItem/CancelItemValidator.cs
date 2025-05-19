using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem
{
    public class CancelItemValidator : AbstractValidator<CancelItemCommand>
    {
        public CancelItemValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");

            RuleFor(x => x.ItemId)
                .NotEmpty()
                .WithMessage("Item ID is required");
        }
    }
}