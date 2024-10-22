using Kashkha.DAL.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly KashkhaContext Context;

        public UsersRepository(KashkhaContext context) : base(context)
        {
            this.Context = context;
        }
        public List<User> GetAll()
        {
           
            
                return Context.Set<User>().ToList();
            

           ;
        }
        public User GetFirstOrDefault(string id)
            
        {
            
            return Context.Set<User>().Include(u=>u.Shop).FirstOrDefault(u=>u.Id==id);
        }
    }
}
