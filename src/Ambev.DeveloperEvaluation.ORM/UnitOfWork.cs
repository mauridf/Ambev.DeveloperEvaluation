using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM;

public class UnitOfWork : IUnitOfWork
{
    private readonly DefaultContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(DefaultContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        // 1. Salva as alterações
        var result = await _context.SaveChangesAsync(cancellationToken);

        // 2. Coleta todas as entidades com eventos
        var domainEntities = _context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        // 3. Publica cada evento
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        // 4. Limpa os eventos de domínio
        domainEntities.ForEach(x => x.Entity.ClearDomainEvents());

        return result;
    }
}
