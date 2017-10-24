using Nymity.Demo.Domain.Interfaces.Service;
using System.Web.Http;

namespace Nymity.Demo.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("orders")]
    public class OrdersController : ApiController
    {
        private IOrderService orderService;

        public OrdersController(IOrderService pOrderService)
        {
            orderService = pOrderService;
        }

        [HttpGet]
        [Route("all/{page:int}")]
        public IHttpActionResult Get(int page = 1)
        {
            return Ok(orderService.GetOrders(page));
        }

        [HttpGet]
        [Route("{id:int:min(1)}/details")]
        public IHttpActionResult GetOrderDetails(int id = 1)
        {
            return Ok(orderService.GetOrderDetailsByOrderId(id));
        }
    }
}
