using Kashkha.API;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public interface IProductManager
	{
		
		List<GetProductDto> GetAll(string? category,Guid? shopId);

		GetProductDto Get(int id);
		public Product GetWithOutUrl(int id);

		void Add(AddProductDto productDto, string userId);
		int? Delete(Product product,string userId);
		int? Update(UpdateProductDto product,string userId);

		//List<GetProductDto> SearchProductByName(string name);

		bool isFound(int id);
	}
}
