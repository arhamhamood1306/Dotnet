using Microsoft.EntityFrameworkCore.Storage;
using AKD.AKDTrading.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKD.AKDTrading.BuildingBlocks.IntegrationEventLogEF.Services
{
    public interface IIntegrationEventLogService
    {
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
        Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction);
        Task MarkEventAsPublishedAsync(Guid eventId);
        Task MarkEventAsInProgressAsync(Guid eventId);
        Task MarkEventAsFailedAsync(Guid eventId);
    }
}
