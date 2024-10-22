
using Microsoft.EntityFrameworkCore;

namespace Kashkha.DAL
{
	public class ProductRepository:GenericRepository<Product>,IProductRepository
	{
		private readonly KashkhaContext _context;
		public ProductRepository(KashkhaContext context):base(context)
		{
			_context = context;
		}

		public IQueryable<Product> SearchProductBy(string? categoryName, Guid? shopId)
		{
		
			if(categoryName is not null && shopId is not null)
			{
				return _context.Set<Product>().Include(p => p.Category).Include(p => p.Rewiews).Include(p => p.Shop).Where(p => p.Category.Name == categoryName && p.ShopId== shopId);

			}
			else if (categoryName is not null)
			{
				return _context.Set<Product>().Include(p => p.Category).Include(p => p.Rewiews).Include(p => p.Shop).Where(p => p.Category.Name == categoryName);

			}
			else
			{
				return _context.Set<Product>().Include(p => p.Category).Include(p => p.Rewiews).Include(p => p.Shop).Where(p => p.ShopId == shopId);
			}
		}

		public bool isFound(int id)
		{

			return _context.Set<Product>().Any(p=>p.Id == id);
		}


		public List<Product> GetAllWithCategory()
		{
			return _context.Set<Product>()
				.Include(p => p.Category).Include(p=>p.Rewiews).Include(p=>p.Shop).ToList();

		}
		public Product? GetByIdWithCategory(int id)
		{
			return _context.Set<Product>()
				.Include(p => p.Category).Include(p => p.Rewiews).Include(p => p.Shop)
				.FirstOrDefault(p => p.Id == id);
		}

	}
}
