/*
 * lufer
 * ISI
 * */

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI1.Model
{
    public enum Roles { Admin, Reader,Editor, User};

    public class User
    {
        static int id=0;        //como autoNumber
        string passwd;

        public string Name { get ; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public string Pass { get=> passwd; set=> passwd=value; }
        public int Id { get => id; set => id = value; }

        public Roles Role { get; set; }
        public string Token { get; set; }

        public User(string name, string pass, string token, Roles r)
        {
            Id = id++;
            Name =name;
            UserName = "";
            Pass = pass;
            Role = r;
            Token = token;
        }

        public User() { }

    }

    //public class Users
    //{
    //    public static List<User> users = new List<User>    
    //    {
    //        new User {
    //            Id=1,
    //            UserName = "Admin",
    //            EmailAddress = "reader1001@me.com",
    //            Role = Roles.Admin
    //        },
    //        new User {
    //            Id = 2,
    //            UserName = "Reader",
    //            EmailAddress = "reader1002@me.com",
    //            Role = Roles.Reader
    //        },
    //        new User {
    //            Id = 3,
    //            UserName = "Editor",
    //            EmailAddress = "reader1003@me.com",
    //            Role = Roles.Editor
    //        }  
    //    };
    //}

}
