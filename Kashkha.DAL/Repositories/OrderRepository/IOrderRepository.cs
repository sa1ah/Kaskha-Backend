
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		public List<Order> GetAll(int id);
		public Order GetOrderById(string UserId, int OrderId);


	}

}
