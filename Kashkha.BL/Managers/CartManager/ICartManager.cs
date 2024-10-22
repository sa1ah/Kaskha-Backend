using Kashkha.BL.DTOs.CartDTOs;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.Managers.CartManager
{
    public interface ICartManager
    {
       Task<CartDTO?> GetCartAsync(string userId);

    Task<CartDTO> AddToCartAsync(string userId, AddToCartDTO addToCartDto);

    Task<CartDTO> UpdateCartItemQuantityAsync(string userId, int productId, int quantity);

    Task<CartDTO> RemoveFromCartAsync(string userId, int productId);

    Task ClearCartAsync(string userId);

    }
}
