﻿using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleCommand : IRequest<CancelSaleResult>
    {
        public Guid SaleId { get; set; }
    }
}