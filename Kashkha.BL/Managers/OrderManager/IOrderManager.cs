using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public interface IOrderManager
	{

		Task<Order?> CreateOrderAsync(string UserId, string CartId, Address ShippingAddress);
		List<Order> GetOrdersForUserAsync(int id);
		public Order GetOrderByIDForUserAsync(string UserID , int OrderId);


	}
}
