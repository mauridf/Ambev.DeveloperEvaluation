﻿using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

public class DeleteSaleRequestValidator: AbstractValidator<DeleteSaleRequest>
{
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
