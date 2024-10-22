using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using System;

public class ShopOwnerDTO
{
    public Guid? Id { get; set; }

    public string? UserId { get; set; }

    public string? ShopName { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public IFormFile? ProfilePicture { get; set; }
   
}