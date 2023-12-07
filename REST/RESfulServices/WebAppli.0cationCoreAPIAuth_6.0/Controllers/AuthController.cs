using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationCoreAPIAuthAula.Data;
using WebApplicationCoreAPIAuthAula.Models;

namespace WebApplicationCoreAPIAuthAula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _config;
        // private UserRepositoryDB _repository;
        private UserRepositoryDB _repository;
        public AuthController(IConfiguration configuration)
        {
            _config = configuration;
            string stringConnection = $"Host={_config["DB_conn:server"]};" +
                $"Username={_config["DB_conn:login"]};" +
                $"Password={_config["DB_conn:password"]};" +
                $"Database={_config["DB_conn:database"]}";
           _repository = new UserRepositoryDB(stringConnection);
           // _repository = new UserRepositoryData(stringConnection);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO loginModel)
        {
            if (ValidarDadosLogin(loginModel)) // loginModel.UserName == loginModel.Password) //; 
            {
                string jwtToken = gerarTokenJWTdetalhado(loginModel); // gerarTokenJWT(); // 
                return Ok(jwtToken);  // 200 - Ok
            }
            return Unauthorized();    // 401 - Unauthorized   
        }



        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO register)
        {
            UserModel user = new UserModel(UserName: register.UserName,
                                           Password: register.Password,
                                           Email: register.Email);
            _repository.AddUser(user);
            return StatusCode(201,$"Register for user '{user.UserName}' has been created."); 
        }


        /*
         * Métodos auxiliares 
         */

        private string gerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var signingKey = _config["Jwt:SigningKey"];

            var expiry = DateTime.Now.AddMinutes(2);  //válido por 2 minutos

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken jwtSecuritytoken = new JwtSecurityToken(
                                                        issuer: issuer, 
                                                        audience: audience,
                                                        expires: expiry, 
                                                        signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            string strJwtSecuritytoken = tokenHandler.WriteToken(jwtSecuritytoken); // Serializes a JwtSecurityToken into a JWT in Compact Serialization Format.

            return strJwtSecuritytoken;
        }

        // versão detalhada com mais informação a ser enviada no token!
        private string gerarTokenJWTdetalhado(UserLoginDTO user) {
            // dados de appsettings.json: Jwt
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var signingKey = _config["Jwt:SigningKey"];

            // 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var expiry = DateTime.Now.AddMinutes(2);  //válido por 2 minutos
            // ---
            //    JwtRegisteredClaimNames:  List of registered claims from different sources
            //    JWT Claims: https://datatracker.ietf.org/doc/html/rfc7519#section-4
            //    OpenID Connect 1.0  https://openid.net/specs/openid-connect-core-1_0.html#IDToken
            // ClaimsIdentity   new ClaimsIdentity(new[]
            var claims = new List<Claim>()                 {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // "jti" (JWT ID) Claim ...a unique identifier for the JWT.
                    //new Claim(JwtRegisteredClaimNames.Iss, issuer),     // 	"iss" (Issuer) Claim (emissor)
                    // new Claim(JwtRegisteredClaimNames.Aud, audience),   // 	"aud" (Audience) Claim 
                    new Claim(JwtRegisteredClaimNames.Sub, "AItOawmwtWwcT0k51BayewNvutrJUqsvl6qs7A4"),  // 	sub" (Subject) Claim  - (assunto) Subject Identifier. A locally unique and never reassigned identifier within the Issuer for the End-User
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())  // "iat" (Issued At) Claim  The "iat" (issued at) claim identifies the time at which the JWT was issued.
                                                                                      // auth_time OpenID Time when the End-User authentication occurred
            };
            claims.Add(new Claim("username", user.UserName)); //   other claims...
           

            // public JwtSecurityToken (string issuer = default, string audience = default,
            //      System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> claims = default,
            //      DateTime? notBefore = default, DateTime? expires = default,
            //      Microsoft.IdentityModel.Tokens.SigningCredentials signingCredentials = default);
            JwtSecurityToken jwtSecuritytoken = new JwtSecurityToken(   
                                                        issuer: issuer,
                                                        audience: audience,
                                                        claims: claims,
                                                        notBefore: DateTime.Now.AddSeconds(30),  //válido após, 30 segundos                                                         expires: expiry,
                                                        expires: expiry ,
                                                        signingCredentials: credentials);
        
       

        var tokenHandler = new JwtSecurityTokenHandler();// A SecurityTokenHandler designed for creating and validating Json Web Tokens
        string strJwtSecuritytoken = tokenHandler.WriteToken(jwtSecuritytoken); // Serializes a JwtSecurityToken into a JWT in Compact Serialization Format.

        return strJwtSecuritytoken;
        }


        private bool ValidarDadosLogin(UserLoginDTO login) {
            bool resultado = false;
            UserModel? user = _repository.GetUserByUserName(login.UserName);

            if (user != null) {
                // if (user.UserName == login.UserName)
                if (user.Password == login.Password)
                    return true;
             }

            return resultado;
        }
    }
}
