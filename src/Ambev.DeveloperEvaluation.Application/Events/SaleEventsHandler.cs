using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Events
{
    public class SaleEventsHandler :
        INotificationHandler<SaleCreatedEvent>,
        INotificationHandler<SaleModifiedEvent>,
        INotificationHandler<SaleCancelledEvent>,
        INotificationHandler<ItemCancelledEvent>
    {
        private readonly ILogger<SaleEventsHandler> _logger;

        public SaleEventsHandler(ILogger<SaleEventsHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleCreated: Sale #{notification.Sale.SaleNumber} created for customer {notification.Sale.CustomerName}");
            return Task.CompletedTask;
        }

        public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleModified: Sale #{notification.Sale.SaleNumber} modified");
            return Task.CompletedTask;
        }

        public Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleCancelled: Sale #{notification.Sale.SaleNumber} cancelled");
            return Task.CompletedTask;
        }

        public Task Handle(ItemCancelledEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"ItemCancelled: Item {notification.Item.ProductName} from Sale #{notification.Sale.SaleNumber} cancelled");
            return Task.CompletedTask;
        }
    }
}