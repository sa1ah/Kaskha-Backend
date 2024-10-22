using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.UserDTOS
{
    public class RegisterDTO
    {
        
        public string Name { get; set; } 
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string C_Password { get; set; }

        public string? Rolename { get; set; }

        public ShopOwnerDTO? Shop { get; set; }
        //public string? ShopName { get; set; }
        //public string? Address { get; set; }
        //public string? ImgUrl { get; set; }
        //[JsonIgnore]
        //public IEnumerable<Order>? Orders { get; set; } = Enumerable.Empty<Order>();
        //[JsonIgnore]
        //public Shop? Shop { get; set; }
    }
}
