using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler to process the creation of a sale.
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateSaleHandler> _logger;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CreateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        // Validação
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Criação da entidade Sale
        var sale = _mapper.Map<Sale>(command);
        sale.SaleDate = DateTime.UtcNow;
        sale.TotalAmount = sale.Items.Sum(i => i.TotalPrice);

        // Salvar no banco de dados
        var createdSale = await _saleRepository.AddAsync(sale);

        // Publicar evento no log
        _logger.LogInformation($"SaleCreated: Venda {createdSale.Id} criada para o cliente {createdSale.Client}.");

        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}
