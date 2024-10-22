using Kashkha.BL;
using Kashkha.BL.DTOs.UserDTOS;
using Kashkha.BL.Helpers;
using Kashkha.DAL;
using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

namespace Kashkha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly IShopManager _shopManager;

        public AccountController(UserManager<User> _userManager,IConfiguration _configuration, IShopManager shopManager)
        {
            userManager = _userManager;
            configuration = _configuration;
            _shopManager = shopManager;
        }

        #region Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO _reginfo)
        {
            var i =Guid.NewGuid();
            //assign user data from dto to database
            if (ModelState.IsValid)
            {
                ShopOwnerDTO shop;
               
                
                var usr = new User()
                {
                    Rolename=_reginfo.Rolename ,
                    UserName = _reginfo.Name,
                    Email = _reginfo.Email,
                    PhoneNumber = _reginfo.Phone   

                };
                var result = await userManager.CreateAsync(usr, _reginfo.Password);
                //check
                if (!result.Succeeded)
                {
                    return BadRequest(new { message = result.Errors });
                }

              

               
                var claims = new List<Claim>
            {
               new (ClaimTypes.NameIdentifier,usr.Id.ToString()),
               new (ClaimTypes.Name,usr.UserName),
               new (ClaimTypes.Email,usr.Email),
               new(ClaimTypes.Role,usr.Rolename)
               };
               
                await userManager.AddClaimsAsync(usr, claims);
				if (_reginfo.Rolename == "Shop Owner")
				{
					usr.ShopId = i;
					shop = new ShopOwnerDTO
					{
						Id = i,
						UserId = usr.Id,
						ShopName = _reginfo.Shop.ShopName,
						ProfilePicture = _reginfo.Shop.ProfilePicture,
						City = _reginfo.Shop.City,
						Street = _reginfo.Shop.Street,



					};

					await _shopManager.AddAsync(shop);
				}

				return Ok(new { message = "sucessed" });
            }
            var errors=ModelState.Values.Select(x=>x.Errors.Select(y=>y.ErrorMessage));
            return BadRequest(new { message = errors });
        }
        #endregion



        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDTO loginDto)
        {
            var  user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new { message = "user not found" }); // 401
            }

            bool isAuthenticated = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isAuthenticated)
            {
                return Unauthorized(new { message = "password is incorrect" }); // 401
            }

            var userClaims = await userManager.GetClaimsAsync(user);
            CreateToken token = new CreateToken();

            return Ok(new { message = "seccess", data = token.GenerateToken(userClaims) });
        }
        #endregion

        #region test
        [HttpPost("check")]
        [Authorize(Roles ="Shop Owner")]
        public IActionResult shopcheck()
        {
            return Ok("hey shop owner");
        }
        #endregion

       

    }
}
