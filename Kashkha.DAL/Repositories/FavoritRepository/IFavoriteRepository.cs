using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    public interface IFavoriteRepository:IGenericRepository<Favorite>
    { 
        Task<Favorite> AddAsync(Favorite favorite);

        Task<Favorite> GetByIdAsync(int id);

        Task<List<Favorite>> GetByUserIdAsync(string userId);

        Task<bool> RemoveAsync(int id);

        Task<bool> ExistsAsync(string userId, int productId);
    }
}
