/*
 * lufer
 * ASP.NET WEB API 3.1
 * ISI
 * */
using System;
using System.Collections.Generic;
// Incluidas
using WebAPI1.Model;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace WebAPI1.Controllers
{
    public interface IJWTAuthManager
    {
        /// <summary>
        /// Várias possibilidades de autenticação
        /// Podem ser criadas mais!
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        AuthResponse Authenticate(AuthRequest loginDetails);
        AuthResponse Authenticate(string username, Claim[] claims);
    }

    /// <summary>
    /// Classe auxiliar para gerir Autenticação e JWT
    /// </summary>
    public class JWTAuthManager : IJWTAuthManager
    {
        /// <summary>
        /// Simula Bases de dados com users registados!
        /// </summary>
        IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" }
        };

        private readonly string tokenKey;

        #region ACEDER_APPSETTINGS.JSON

        //caso se pretenda aceder a appsettings.json
        private IConfiguration _config;
        /// <summary>
        /// instanciado em startup.cs:
        /// services.AddSingleton<IConfiguration>(Configuration)
        /// </summary>
        /// <param name="Configuration"></param>
        public JWTAuthManager(IConfiguration Configuration)
        {
            _config = Configuration;                            //para aceder a appsettings.json
        }
        #endregion

        /// <summary>
        /// Gere Token: instanciado em Startup.cs
        /// </summary>
        /// <param name="tokenKey"></param>
        public JWTAuthManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        
        /// <summary>
        /// h1: Autenticar com Claims
        /// </summary>
        /// <param name="username"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public AuthResponse Authenticate(string username, Claim[] claims)
        {
            var token = GenerateTokenString(username, DateTime.UtcNow, claims);
            
            return new AuthResponse
            {
                Name = username,
                Token = token
            };
        }

        /// <summary>
        /// h2:Autenticar sem Claims mas apenas com login/password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AuthResponse Authenticate(AuthRequest loginDetails)
        {
            if (!ValidarUser(loginDetails)) return null;

            var token = GenerateTokenString(loginDetails.Username, DateTime.UtcNow);

            return new AuthResponse
            {
                Name = loginDetails.Username,
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60)
            };
        }

        #region GerarTokens

        /// <summary>
        /// H1: Gerar JWT token!
        /// Caso existam claims...
        /// </summary>
        /// <param name="username"></param>
        /// <param name="expires"></param>
        /// <param name="claims">Claims Opcional!!!</param>
        /// <returns></returns>
        string GenerateTokenString(string username, DateTime expires, Claim[] claims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                 claims ?? new Claim[]              //caso existam claims usar, senão, criar novo com username
                    //ver exemplo com claims!
                 
                 {
                    new Claim(ClaimTypes.Name, username)
                }),
                //NotBefore = expires,
                Expires = expires.AddMinutes(60),    //expira em 60 minutos
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }


        /// <summary>
        /// H2: Gerar JWT por defeito
        /// </summary>
        /// <returns></returns>
        string GenerateTokenString()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);  //válido por 2 horas
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        #endregion

        #region ValidaUser

        /// <summary>
        /// Certificar dados de autenticação
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns></returns>
        private bool ValidarUser(AuthRequest loginDetalhes)
        {
            //ou verificar na BD da classe "Users"
            //var user = users.SingleOrDefault(x => x.Username == loginDetalhes.Username && x.Password == loginDetalhes.Password);

            if (loginDetalhes.Username == "lufer" && loginDetalhes.Password == "Benfica2023")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        #endregion
    }
}
