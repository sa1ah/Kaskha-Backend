using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.ShopOwnerDTOs
{
    public class GetOwnerinfo
    {

        public Guid? Id { get; set; }

        public string? UserId { get; set; }

        public string? ShopName { get; set; }

        public string? City { get; set; }
        public string? phone { get; set; }

        public string? Street { get; set; }

        public string? ProfilePicture { get; set; }
        public ICollection<Product>? Product { get;set;}=new List<Product>();
	}
}
