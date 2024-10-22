using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL.Models
{
    public class CartItem
    {

    
    public int ProductId { get; set; }
        public  string PicUrl { get; set; }

        public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice => Price * Quantity;
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    }
}
