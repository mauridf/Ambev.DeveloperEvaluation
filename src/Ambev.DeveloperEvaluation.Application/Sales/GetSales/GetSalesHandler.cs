using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesHandler : IRequestHandler<GetSalesQuery, List<GetSalesResult>>
{
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    public GetSalesHandler(ISaleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetSalesResult>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
    {
        var sales = await _repository.GetAllAsync();
        return _mapper.Map<List<GetSalesResult>>(sales);
    }
}
