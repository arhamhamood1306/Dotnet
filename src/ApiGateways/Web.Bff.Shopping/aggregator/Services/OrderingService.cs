using AKD.AKDTrading.Web.HttpAggregator.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace AKD.AKDTrading.Web.HttpAggregator.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly ILogger<OrderingService> _logger;

        public OrderingService(ILogger<OrderingService> logger)
        {
            _logger = logger;
        }

        public async Task<OrderData> GetOrderDraftAsync()
        {
            _logger.LogDebug(" grpc client created, basketData={@basketData}", null);

            _logger.LogDebug(" grpc response: {@response}", null);

            return MapToResponse();
        }

        private OrderData MapToResponse()
        {
            var data = new OrderData
            {
                Buyer = null,
            };

            return data;
        }
    }
}
