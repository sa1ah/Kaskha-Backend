using Kashkha.DAL.Repositories.UsersRepository;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class UnitOfWork : IDisposable, IUnitOfWork
	{
		private readonly KashkhaContext _context;
		public IProductRepository _ProductRepository { get; private set; }
		public IReviewRepository _reviewRepository { get; private set; }
		public IOrderRepository _orderRepository { get; private set; }
		public IOrderItemRepository _orderItemRepository { get; private set; }
		public ICartRepository _cartRepository { get; private set; }
        public IUsersRepository _usersRepository { get; private set; }
		public IShopRepository _shopRepository { get; private set; }
		public IFavoriteRepository _favoriteRepository { get; private set; }

		public UnitOfWork(KashkhaContext context, IConnectionMultiplexer redis)
		{
			_ProductRepository = new ProductRepository(context);
			_reviewRepository = new ReviewRepository(context);
			_orderRepository = new OrderRepository(context);
			_orderItemRepository= new OrderItemRepository(context);
			_cartRepository= new CartRepository(redis);
            _usersRepository = new UsersRepository(context);
			_shopRepository = new ShopRepository(context);
			_favoriteRepository = new FavoritRepository(context);


            _context = context;
		}



		public void Dispose()
		{
			_context.Dispose();
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}
	}
}
