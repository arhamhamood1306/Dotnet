using AKD.AKDTrading.Mobile.HttpAggregator.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace AKD.AKDTrading.Mobile.HttpAggregator.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly ILogger<OrderingService> _logger;

        public OrderingService(ILogger<OrderingService> logger)
        {
            _logger = logger;
        }

        public async Task<OrderData> GetOrderDraftAsync(BasketData basketData)
        {
            _logger.LogDebug(" grpc client created, basketData={@basketData}", basketData);

            _logger.LogDebug(" grpc response: {@response}", null);

            return MapToResponse(basketData);
        }

        private OrderData MapToResponse(BasketData basketData)
        {
            var data = new OrderData
            {
                Buyer = basketData.BuyerId,
            };

            return data;
        }
    }
}
