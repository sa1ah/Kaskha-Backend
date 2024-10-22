using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderManager _orderManager;

		public OrdersController(IOrderManager orderManager)
		{
			_orderManager = orderManager;
		}
		[HttpPost]
		public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDto orderDto)
		{
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Address address = new Address()
			{
				City = orderDto?.Ciry,
				Country = orderDto.Country,
				Name = orderDto.Name,
				Street = orderDto.Street
			};
			var order = await _orderManager.CreateOrderAsync(userId, orderDto.CartId, address);

			if (order is null) return BadRequest();

			return Ok(order);
		}
		[HttpGet("{id:int}")]
		public ActionResult<Order> GetOrder(int id)
		{
			var orders =  _orderManager.GetOrdersForUserAsync(id);
			if(orders?.Count() <0)
			{
				return NotFound();
			}
			return Ok(orders);
		}

		[HttpGet("OrderById")]
		public  ActionResult<Order> GetOrderById([FromQuery] int OrderId)
		{
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orders =  _orderManager.GetOrderByIDForUserAsync(userId, OrderId);
			if (orders is null)
			{
				return NotFound();
			}
			return Ok(orders);

		}



	}
}
