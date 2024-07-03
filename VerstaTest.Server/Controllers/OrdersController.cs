using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VerstaTest.Core.Abstractions;
using VerstaTest.Server.Contracts;
using VerstaTest.Server.Model;

namespace VerstaTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetOrders()
        {
            var orders = await _ordersService.GetAllOrders();

            var responce = orders.Select(o => new OrderResponse(
                o.Id,
                o.RecipientCity,
                o.RecipientAddress,
                o.AddresserCity,
                o.AddresserAddress,
                o.CargoWeight,
                o.ReceiveDate
                ));
            return Ok(responce);

        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] OrderRequest request)
        {
            var order = Order.Create(
                Guid.NewGuid(),
                request.RecipientCity,
                request.RecipientAddress,
                request.AddresserCity,
                request.AddresserAddress,
                request.CargoWeight,
                request.RecieveDate);

            var bookId = await _ordersService.CreateOrder(order);

            return Ok(bookId);
        }

    }
}
