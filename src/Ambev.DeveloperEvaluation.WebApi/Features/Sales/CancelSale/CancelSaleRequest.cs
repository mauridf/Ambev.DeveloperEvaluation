using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    public class CancelSaleRequest
    {
        public Guid SaleId { get; set; }
    }

    public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
    {
        public CancelSaleRequestValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty();
        }
    }
}