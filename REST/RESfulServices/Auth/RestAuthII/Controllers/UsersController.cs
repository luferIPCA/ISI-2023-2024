/**
 * lufer
 * ISI - 2023
 * Roules/Authorization
 * */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate(AuthenticateModel model)
        {
            var user = userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [Authorize(Roles = Role.User)]
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = "Admin,User")]       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user =  userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/values
        [Authorize(Roles = Role.Admin)]
        [HttpPost("addUser")]
        public ActionResult<bool> Post(User u)
        {
            //
            return (userService.AddUser(u));

        }

        // PUT api/values/5
        [Authorize(Roles = Role.Admin)]
        [HttpPatch("updatePass/{name}")]    //PATCH...update properties
                                            //public ActionResult<bool> ChangePass(string name, [FromBody] string passwd)
        public ActionResult<bool> ChangePass(string name, string passwd)
        {

            return (userService.ChangePass(name, passwd));

        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("updateUser")]
        public ActionResult<bool> Put(User u)
        {
            return (userService.Put(u));
        }

        // DELETE api/values/5
        [Authorize(Roles = Role.Admin)]
        //[Authorize]
        [HttpDelete("deleteUser/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return userService.Delete(id);

        }


    }
}
