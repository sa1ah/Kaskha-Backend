using Kashkha.DAL.Repositories.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public interface IUnitOfWork
	{
		public IProductRepository _ProductRepository { get; }
		public IReviewRepository _reviewRepository { get; }
		public IOrderRepository _orderRepository { get; }
		public IOrderItemRepository _orderItemRepository { get; }
		public ICartRepository _cartRepository { get; }
        public IUsersRepository _usersRepository { get; }
        public IShopRepository _shopRepository { get; }
        public IFavoriteRepository _favoriteRepository { get; }



        int Complete();
	}
}
