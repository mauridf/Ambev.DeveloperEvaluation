# Domain Events

## SaleCreatedEvent
Triggered when a new sale is created.

## SaleModifiedEvent
Triggered when a sale's customer or values are modified.

## SaleCancelledEvent
Triggered when a sale is marked as cancelled.

## ItemCancelledEvent
Triggered when a sale item is marked as cancelled.

These events are published using MediatR and can be extended to integrate with external systems or logs.