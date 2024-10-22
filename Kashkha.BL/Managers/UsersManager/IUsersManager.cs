using Kashkha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.Managers.UsersManager
{
    public interface IUsersManager
    {
        public List<User> GetAll();
        public User GetFirstOrDefault(string id);
        //public User Edit(User _userfrmrequest);
        public void Delete(User _userfrmrequest);
        
    }
}
