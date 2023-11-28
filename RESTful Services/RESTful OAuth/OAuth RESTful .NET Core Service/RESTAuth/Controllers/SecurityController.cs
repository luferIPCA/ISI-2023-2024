/*
 * lufer
 * ISI
 * */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using RESTAuth.Models;

namespace RESTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        //classe que gera o JWT
        private readonly IJWTAuthManager jWTAuthManager;

        public SecurityController(IJWTAuthManager jWTAuthManager)
        {
            this.jWTAuthManager = jWTAuthManager;

        }

        /// <summary>
        /// Método para Autenticação...não protegido!
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public  AuthResponse Login(AuthRequest loginDetalhes) //or ([FromBody] AuthRequest loginDetalhes)
        {
            AuthResponse token = jWTAuthManager.Authenticate(loginDetalhes);

            if (token == null)
            {
                token.Token = Unauthorized().ToString();
            }

            return token;

            /*
             * Se retorno for IActionResult:
             *
             * if (token == null)
             *       return Unauthorized();
             *  return Ok(token);
             */
        }
    }
}
