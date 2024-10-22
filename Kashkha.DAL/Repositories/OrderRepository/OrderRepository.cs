using Kashkha.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		private readonly KashkhaContext _context;

		public OrderRepository(KashkhaContext context) : base(context)
		{
			_context = context;
		}

		public List<Order> GetAll(int id)
		{
			//Where(o => o.UserId == id && o.Id==4).ToList()
			return _context.Set<Order>().Include(o=>o.orderItems).ToList();

		}

		public Order GetOrderById(string UserId, int OrderId)
		{

			return _context.Set<Order>().FirstOrDefault(o => o.UserId == UserId && o.Id == OrderId);

		}
	}
}
