using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AKD.AKDTrading.Mobile.HttpAggregator.Models;
using AKD.AKDTrading.Mobile.HttpAggregator.Services;
using System.Net;
using System.Threading.Tasks;

namespace AKD.AKDTrading.Mobile.HttpAggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderingService _orderingService;

        public OrderController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [Route("draft/{basketId}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OrderData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderData>> GetOrderDraftAsync(string basketId)
        {
            if (string.IsNullOrEmpty(basketId))
            {
                return BadRequest("Need a valid basketid");
            }
            // Get the basket data and build a order draft based on it

            return null;
        }
    }
}
