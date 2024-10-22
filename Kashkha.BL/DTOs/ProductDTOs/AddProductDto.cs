
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.API
{
	public class AddProductDto
	{
		public string ProductName { get; set; }
		public string? Description { get; set; }
		public IFormFile? Image { get; set; }
		public decimal Price { get; set; }
		public int? CategoryId { get; set; }
		public int Quantity { get; set; }


		//shop owner
		//public int UserId { get; set; }
	}
}
