using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace RestAPIGoogle.Controllers
{
    [ApiController]
    [AllowAnonymous, Route("account")]
    public class AccountController : ControllerBase
    {

        [HttpGet("get/{id}")]
        //[Authorize]
        public ActionResult<string> Get(int id)
        {
            return Ok("Funciona");// this.User.Identity.Name;
        }

        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            string json = JsonSerializer.Serialize(claims);
            return Ok(json);
        }
    }
}
