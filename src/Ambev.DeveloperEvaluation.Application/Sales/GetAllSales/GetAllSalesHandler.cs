using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, List<GetAllSalesResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllSalesResult>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            // Obter todas as vendas
            var sales = await _saleRepository.GetAllAsync();

            // Mapear para o resultado
            return _mapper.Map<List<GetAllSalesResult>>(sales);
        }
    }
}
