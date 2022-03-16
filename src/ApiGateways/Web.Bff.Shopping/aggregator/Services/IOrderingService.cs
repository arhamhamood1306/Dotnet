using AKD.AKDTrading.Web.HttpAggregator.Models;
using System.Threading.Tasks;

namespace AKD.AKDTrading.Web.HttpAggregator.Services
{
    public interface IOrderingService
    {
        Task<OrderData> GetOrderDraftAsync();
    }
}