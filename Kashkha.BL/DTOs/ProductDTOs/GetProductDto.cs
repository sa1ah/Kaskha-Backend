using Kashkha.DAL;
using Microsoft.AspNetCore.Http;

namespace Kashkha.API
{

	public class test
	{

		public int Id { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string comment { get; set; }



	}

	public class GetProductDto
	{

		public int Id { get; set; }
		public string ProductName { get; set; }
		public string? Description { get; set; }
		public string? Image { get; set; } 
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int? CategoryId { get; set; }
		public string? CategoryName { get; set; }
		public Guid ShopId { get; set; }
		public string ShopName { get; set; }
		public string ShopImage { get; set; }
		public ICollection<Review>? ProductRewiews { get; set; } = new List<Review>();

		//shop owner
		//public int UserId { get; set; }

	}

}
