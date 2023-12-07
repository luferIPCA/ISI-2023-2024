/**
 * lufer
 * ISI - 2023
 * Roules/Authorization
 * */

using System;
using System.Text.Json.Serialization;

namespace WebApi.Entities
{
    
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}