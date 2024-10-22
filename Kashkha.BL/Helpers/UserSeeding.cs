using Kashkha.BL.Managers.UsersManager;
using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.Helpers
{
    public class UserSeeding
    {
        private readonly UserManager<User> _userManager;
       
        public static async Task SeedUser(UserManager<User> userManager)
        {
            if (!userManager.Users.Any(u=>u.Rolename=="Admin"))
            {

                User sedusr = new User()
                {
                  UserName = "Admin",
                  Email="admin.super@gmail.com",
                  Rolename="Admin",
                  PhoneNumber="01063046344"
                };
                await userManager.CreateAsync(sedusr,"Admin123");
            }
        }
        
        
        
    }
}



            
      
     