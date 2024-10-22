using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kashkha.DAL
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        private readonly KashkhaContext _context;
        public ShopRepository(KashkhaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Shop> GetByIdAsync(string id)
        {
            return await _context.Shop.Include(u=>u.Products).Include(u => u.User).FirstOrDefaultAsync(u=>u.UserId==id);
        }

        public async Task<Shop> GetShopByIdAsync(Guid shopId)
        {
            return await _context.Shop.Include(s=> s.Products).FirstOrDefaultAsync(s=>s.Id==shopId);
        }

        // public async Task<IEnumerable<ShopOwner>> GetAllAsync()
        // {
        //     return await _context.ShopOwners.ToListAsync();
        // }

        public async Task<Shop> AddAsync(Shop shopOwner)
        {
            await _context.Shop.AddAsync(shopOwner);
            await _context.SaveChangesAsync();
            return shopOwner;
        }

        public async Task UpdateAsync(Shop shopOwner)
        {
            _context.Entry(shopOwner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var shopOwner = await _context.Shop.FindAsync(id);
            if (shopOwner != null)
            {
                _context.Shop.Remove(shopOwner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
