using AKD.AKDTrading.Mobile.HttpAggregator.Models;
using System.Threading.Tasks;

namespace AKD.AKDTrading.Mobile.HttpAggregator.Services
{
    public interface IOrderingService
    {
        Task<OrderData> GetOrderDraftAsync(BasketData basketData);
    }
}