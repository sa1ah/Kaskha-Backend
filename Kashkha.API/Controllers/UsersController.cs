using Kashkha.BL.Managers.UsersManager;
using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kashkha.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _usersManager;

        public UsersController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            return Ok(_usersManager.GetAll());
        }
        [HttpGet]

        [Route("Getid/{id:guid}")]
        [Authorize(Roles = "Admin")]

        public IActionResult  GetFirstOrDefault(string id)
        {
            return Ok(_usersManager.GetFirstOrDefault(id));
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(string id)
        {
            User? user = _usersManager.GetFirstOrDefault(id);
            _usersManager.Delete(user);
            return Ok();
        }
    }
}
