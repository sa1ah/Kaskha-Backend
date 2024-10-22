using Kashkha.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace Kashkha.DAL
{
	public class Shop
    {

        public Guid Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User? User { get; set; }



        public string ShopName { get; set; }
        public Address Address { get; set; }

        public string ProfilePicture { get; set; }

        public ICollection<Product> Products { get; set; }=new List<Product>();
        // public ICollection<Order> Orders { get; set; }
    }

}
