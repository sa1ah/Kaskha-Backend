using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Kashkha.DAL
{
	public class Product : BaseEntity
	{

		public string Name { get; set; }
		public string? Description { get; set; }
		public string? PictureUrl { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
		
		
		public ICollection<Review>? Rewiews { get; set; } = new List<Review>();


		//shop owner
		[ForeignKey("Shop")]
		public Guid ShopId { get; set; }
		[JsonIgnore]
		public Shop? Shop { get; set; }


	}
}
