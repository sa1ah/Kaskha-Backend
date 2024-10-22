using Kashkha.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class Favorite
	{
		
      
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User? User { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
      
        public Product? Product { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
