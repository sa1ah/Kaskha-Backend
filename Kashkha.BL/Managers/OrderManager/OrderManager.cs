using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class OrderManager : IOrderManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderManager(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}


        public async Task<Order?> CreateOrderAsync(string UserId, string CartId, Address ShippingAddress)
		{
			// 1 - Get basket From Basket Repo
			   var basket = await _unitOfWork._cartRepository.GetCartAsync(CartId);
            // 2 - Get Select Items at Cart From Product Repo
			   var  orderItems = new List<OrderItem>();
			if(basket?.Items?.Count>0)
			{
				foreach (var item in basket.Items)
				{
					var product = _unitOfWork._ProductRepository.GetFirstOrDefault(item.ProductId);
					var orderItem = new OrderItem()
					{
						ProductId = product.Id,
						ProductName = product.Name,
						PicturUrl = product.PictureUrl,
						Price = product.Price,
						Quantity = item.Quantity
					};
					orderItems.Add(orderItem);
			    }
			}

			// 3 - Calculate SubTotal 
			var subTotal = orderItems.Sum(x => x.Price * x.Quantity);

			//5- Create Order
			var order = new Order() {
				orderItems = orderItems,
				OrderAddress = ShippingAddress,
				OrderDate =  DateTime.Now.AddDays(3),
				OrderStatus=OrderStatus.Pending,
				ShippingDate = DateTime.Now,
				PaymentStatus=PaymentStatus.Pending,
				TotalPrice=subTotal,
				Carrier="Mohamed Ali",
				UserId=UserId,
			};
			// 6- save to Database 
			_unitOfWork._orderRepository.Add(order);
			foreach (var item in order.orderItems)
			{
				item.Order = order;
				_unitOfWork._orderItemRepository.Add(item);
			}
			var result =  _unitOfWork.Complete();

			if (result <= 0) return null;

			return order;

		}

		public Order GetOrderByIDForUserAsync(string UserID, int OrderId)
		{
			return _unitOfWork._orderRepository.GetOrderById(UserID, OrderId);
 		}

        public List<Order> GetOrdersForUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
