using System;
using Kashkha.API;

namespace Kashkha.BL.DTOs
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        //public GetProductDto Product { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}