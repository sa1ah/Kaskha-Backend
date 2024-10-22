using AutoMapper;
using Kashkha.BL.DTOs.CartDTOs;
using Kashkha.BL.Mapping;
using Kashkha.DAL;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kashkha.BL.Managers.CartManager
{
    public class CartManager : ICartManager
    {

        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public CartManager(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper, IConfiguration configuration)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _config = configuration;
        }

        public async Task<CartDTO?> GetCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            foreach (var item in cart.Items)
            {
                item.PicUrl = _config["ApiBaseUrl"] + item.PicUrl;
            }
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task<CartDTO> AddToCartAsync(string userId, AddToCartDTO addToCartDto)
        {
            var cartEntity = await _cartRepository.GetCartAsync(userId);
            var cart = _mapper.Map<CartDTO>(cartEntity) ?? new CartDTO { UserId = userId };

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == addToCartDto.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += addToCartDto.Quantity;
            }
            else
            {
                var product = _productRepository.GetFirstOrDefault(addToCartDto.ProductId);
                if (product == null)
                {
        throw new KeyNotFoundException($"Product with ID {addToCartDto.ProductId} not found");
                }

                cart.Items.Add(new CartItemDTO
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    PicUrl=product.PictureUrl,
                    Price = product.Price,
                    Quantity = addToCartDto.Quantity
                });
            }

            var updatedCartEntity = _mapper.Map<Cart>(cart);
            await _cartRepository.SetCartAsync(userId, updatedCartEntity);
            return cart;
        }

        public async Task<CartDTO> UpdateCartItemQuantityAsync(string userId, int productId, int quantity)
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            if (cart == null)
            {
                throw new ArgumentException("Cart not found");
            }

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                throw new ArgumentException("Product not in cart");
            }

            if (quantity <= 0)
            {
                cart.Items.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }

            await _cartRepository.SetCartAsync(userId, cart);
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task<CartDTO> RemoveFromCartAsync(string userId, int productId)
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            if (cart == null)
            {
                throw new ArgumentException("Cart not found");
            }

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
                await _cartRepository.SetCartAsync(userId, cart);
            }

            await _cartRepository.SetCartAsync(userId, cart);
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task ClearCartAsync(string userId)
        {
            await _cartRepository.DeleteCartAsync(userId);
        }
    }
}
