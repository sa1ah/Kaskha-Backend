using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class AddressDto
	{
		

	}


	public class OrderDto
	{
		public string CartId { set; get; }

        public string Name { get; set; }
        public string Street { get; set; }
        public string Ciry { get; set; }
        public string Country { get; set; }

    }



}
