
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class OrderItem : BaseEntity
	{
		[ForeignKey("Order")]
		public int OrderId { get; set; }

		//[JsonIgnore]
		public Order? Order { get; set; }

		//[ForeignKey("Product")]
		public int ProductId { get; set; }
		[NotMapped]
		public Product? Product { get; set; }

		public string ProductName { get; set; }

		public string PicturUrl { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public decimal TotalPrice => Price * Quantity;

	
	}
}
