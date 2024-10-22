using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	[NotMapped]
	public class Address //  ده مش هيتحول ل table 
	{
       
		public string? Name { get; set; }
		public string? City { get; set; }
		public string? Street { get; set; }
		public string? Country { get; set; }


	}
}
