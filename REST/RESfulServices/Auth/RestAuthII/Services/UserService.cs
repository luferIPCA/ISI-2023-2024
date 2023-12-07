using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using WebApi.Models;
using WebApi.Entities;


namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);

        bool AddUser(User u);
        bool ChangePass(string name, string passwd);
        bool Put(User u);
        bool Delete(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity
        private List<User> users = new List<User>
        { 
            new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin", Role = Role.Admin },
            new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = "user", Role = Role.User } 
        };

        private readonly AppSettings appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        /// <summary>
        /// Generate JWT
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            var user = users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
			
			//Secret comes from appsettings.json
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //claim foreach Role
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    //new Claim(ClaimTypes.Role, user.User)
                }),
                //token expiration date
                Expires = DateTime.UtcNow.AddSeconds(60),//.AddHours(2), // AddDays(7)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Expiration = DateTime.Now.AddMinutes(120);     //
           
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(int id) 
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public bool AddUser(User u)
        {
            if (users.Contains(u)) return false;
            users.Add(u);
            return true;
        }

        public bool ChangePass(string name, string passwd)
        {

            int i = users.FindIndex(x => x.Username == name);
            if (i >= 0)
            {
                users[i].Password = passwd;
                return true;
            }
            return false;
        }

        public bool Put(User u)
        {
            int i = users.FindIndex(x => x.Id == u.Id);
            if (i >= 0)
            {
                users[i].Password = u.Password;
                users[i].Username = u.Username;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            User aux = users.Single<User>(x => x.Id == id);
            if (aux != null)
            {
                users.Remove(aux);
                return true;
            }
            return false;
        }
    }
}