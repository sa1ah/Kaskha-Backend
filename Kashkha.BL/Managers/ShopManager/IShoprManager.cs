using Kashkha.BL.DTOs.ShopOwnerDTOs;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IShopManager
{
    Task<GetOwnerinfo> GetByIdAsync(string id);
    // Task<IEnumerable<ShopOwnerDTO>> GetAllAsync();
    Task<Shop> GetShopByIdAsync(Guid shopId);
	Task<int?> AddAsync(ShopOwnerDTO shopOwnerDto);
    Task UpdateAsync(ShopOwnerDTO shopOwnerDto);
    Task DeleteAsync(Guid id);
}