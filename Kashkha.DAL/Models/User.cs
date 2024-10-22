using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.DAL.Models
{
    public class User:IdentityUser
    {

        
        public string Rolename { get; set; }
      
        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; } = Enumerable.Empty<Order>();
        

        public Guid? ShopId { get; set; }
        [JsonIgnore]
        public Shop? Shop { get; set; }

    }
}
