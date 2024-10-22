using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.CartDTOs
{
	public class AddToCartDTO
	{ 
		//Used when adding an item to the cart, containing product ID and quantity
		public int ProductId { get; set; }
		
		public int Quantity { get; set; }
	}
}

