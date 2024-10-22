using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class Category:BaseEntity //Add by super Admin
	{

		public string? Name { get; set; }
		public string? Description { get; set; }
		public ICollection<Product>? Products { get; set; }= new HashSet<Product>();
    }
}
