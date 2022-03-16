using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AKD.AKDTrading.Web.HttpAggregator.Models;
using AKD.AKDTrading.Web.HttpAggregator.Services;
using System.Net;
using System.Threading.Tasks;

namespace AKD.AKDTrading.Web.HttpAggregator.Controllers
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

            return await _orderingService.GetOrderDraftAsync();
        }
    }
}
