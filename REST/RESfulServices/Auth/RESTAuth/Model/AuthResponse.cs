/*
 * lufer
 * ISI
 * OAuth
 * See https://dotnetcorecentral.com/blog/asp-net-core-authorization/
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI1.Model
{
    public class AuthResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public AuthResponse() { }
        public AuthResponse(string user, string token)
        {
            Name = user;
            Token = token;
            Expiration = DateTime.Now.AddMinutes(120);
        }

        public AuthResponse(AuthRequest user, string token, DateTime expires)
        {
            Name = user.Username;
            Token = token;
            Expiration = expires;
        }
    }
}
