using Kashkha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL.Repositories.UsersRepository
{
    public interface IUsersRepository:IGenericRepository<User>
    {
        public List<User> GetAll();
        public User GetFirstOrDefault(string id);

    }
}
