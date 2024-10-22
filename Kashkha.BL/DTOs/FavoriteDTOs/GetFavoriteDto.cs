using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.FavoriteDTOs
{
    public class GetFavoriteDto
    {
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public string categoryName { get; set; }
        public string shopId { get; set; }
        public string shopName { get; set; }
        public string shopImage { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}