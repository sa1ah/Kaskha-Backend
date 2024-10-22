using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kashkha.DAL
{
    public class FavoritRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        private readonly KashkhaContext _context;
        public FavoritRepository(KashkhaContext context) : base(context)
        {
            _context=context;
        }

          public async Task<Favorite> AddAsync(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task<Favorite> GetByIdAsync(int id)
        {
            return await _context.Favorites.FindAsync(id);
        }

        public async Task<List<Favorite>> GetByUserIdAsync(string userId)
        {
            return await _context.Favorites.Include(f => f.Product).Include(f => f.Product.Category).Include(f => f.Product.Shop).Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null) return false;
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(string userId, int productId)
        {
            return await _context.Favorites
                .AnyAsync(f => f.UserId == userId && f.ProductId == productId);
        }
    }
}
