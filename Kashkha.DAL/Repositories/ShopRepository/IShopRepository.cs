using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    public interface IShopRepository:IGenericRepository<Shop>
    {
        Task<Shop> GetByIdAsync(string id);
        Task<Shop> GetShopByIdAsync(Guid id);

        //  Task<IEnumerable<ShopOwner>> GetAllAsync();
        Task<Shop> AddAsync(Shop shop);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Guid id);
    }
}
