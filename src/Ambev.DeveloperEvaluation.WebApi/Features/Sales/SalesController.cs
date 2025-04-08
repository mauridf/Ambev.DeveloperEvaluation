using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria uma nova venda
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CreateSaleResponse>> Create([FromBody] CreateSaleRequest request)
    {
        var command = _mapper.Map<CreateSaleCommand>(request);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, _mapper.Map<CreateSaleResponse>(result));
    }

    /// <summary>
    /// Atualiza uma venda existente
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateSaleResponse>> Update(Guid id, [FromBody] UpdateSaleRequest request)
    {
        request.Id = id;
        var command = _mapper.Map<UpdateSaleCommand>(request);
        var result = await _mediator.Send(command);
        return Ok(_mapper.Map<UpdateSaleResponse>(result));
    }

    /// <summary>
    /// Remove uma venda
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteSaleCommand(id); // Correção aqui
        await _mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Retorna uma venda pelo ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetSaleResponse>> GetById(Guid id)
    {
        var query = new GetSaleQuery(id); // Correção aqui
        var result = await _mediator.Send(query);
        return Ok(_mapper.Map<GetSaleResponse>(result));
    }

    /// <summary>
    /// Lista vendas (pode filtrar por UserId)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetSalesResponse>>> GetAll([FromQuery] GetSalesRequest request)
    {
        var query = _mapper.Map<GetSalesQuery>(request);
        var result = await _mediator.Send(query);
        var response = _mapper.Map<List<GetSalesResponse>>(result);
        return Ok(response);
    }
}
