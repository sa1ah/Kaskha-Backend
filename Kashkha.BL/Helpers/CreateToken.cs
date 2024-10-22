using Kashkha.BL.DTOs.UserDTOS;
using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.Helpers
{
    public class CreateToken
        
    {
        //private readonly IConfiguration _configuration;

        //public CreateToken(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
        {
            var keyFromConfig = "555555555555s55555ssssassas55@@@@@#######";
            var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiryDateTime = DateTime.Now.AddMinutes(50);

            var jwt = new JwtSecurityToken(
                claims: userClaims,
                expires: expiryDateTime,
                signingCredentials: signingCredentials);

            var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenDto(jwtAsString, expiryDateTime);
        }
    }
}
