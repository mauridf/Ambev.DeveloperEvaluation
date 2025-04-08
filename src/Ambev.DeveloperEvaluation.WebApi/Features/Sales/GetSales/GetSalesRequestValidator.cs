using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesRequestValidator : AbstractValidator<GetSalesRequest>
{
    public GetSalesRequestValidator()
    {
        // UserId é opcional, mas se vier, deve ser válido
        When(x => x.UserId.HasValue, () =>
        {
            RuleFor(x => x.UserId.Value)
                .NotEqual(Guid.Empty).WithMessage("UserId cannot be empty.");
        });
    }
}
