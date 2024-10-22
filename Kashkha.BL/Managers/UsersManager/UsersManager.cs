using Kashkha.DAL;
using Kashkha.DAL.Models;
using Kashkha.DAL.Repositories.UsersRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.Managers.UsersManager
{
    public class UsersManager : IUsersManager
       
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IUsersRepository usersRepository;

        public UsersManager(UnitOfWork _unitOfWork,IUsersRepository usersRepository)
        {
            unitOfWork = _unitOfWork;
            this.usersRepository = usersRepository;
        }
        public void Delete(User _userfrmrequest)
        {
            unitOfWork._usersRepository.Delete(_userfrmrequest);/////////////////////////
            var result =unitOfWork.Complete();
        }

        //public User Edit(User _userfrmrequest)
        //{
        //    User _user = new User()
        //    {
        //        UserName = _userfrmrequest.UserName,
        //        Email = _userfrmrequest.Email,
        //        PhoneNumber = _userfrmrequest.PhoneNumber,
        //        Rolename = _userfrmrequest.Rolename
        //    };
        //}

        public List<User> GetAll()
        {

            List<User> users = new List<User>();
            users= unitOfWork._usersRepository.GetAll();
            return users;
            

        }

        public User GetFirstOrDefault(string id)
        {
            User user = new User();
            user=unitOfWork._usersRepository.GetFirstOrDefault(id);
            
            return user;
        }
    }
}
