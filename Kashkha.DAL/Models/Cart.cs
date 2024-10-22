
using Kashkha.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kashkha.DAL
{
    public class Cart
    {

        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } // Assuming you're using ASP.NET Core Identity
        public User? User { get; set; }
        public List<CartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

        public Cart(int id)
        {
            Id = id;
        }

    }
}
