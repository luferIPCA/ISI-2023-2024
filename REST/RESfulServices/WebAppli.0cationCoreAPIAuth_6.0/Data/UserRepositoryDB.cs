

using Npgsql;
using System.Security.Cryptography;
using WebApplicationCoreAPIAuthAula.Models;
using static System.Net.WebRequestMethods;

namespace WebApplicationCoreAPIAuthAula.Data
{
    public class UserRepositoryDB
    {
        private readonly string _connString;

       // uso do ADO.NET como driver de acesso, usando npgsql(https://www.npgsql.org/).
       // documentação já lhes dará as bases necessárias:  https://www.npgsql.org/doc/basic-usage.html

        public UserRepositoryDB(string connectionString)
        {
            _connString = connectionString ;
            CreateTableUsers();

        }

        private void CreateTableUsers() {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Create a new table (if not exist)
            var sql = "CREATE TABLE IF NOT EXISTS users (" +
                                "username varchar(10) NOT NULL PRIMARY KEY," +
                                "email varchar(45) NOT NULL UNIQUE," +
                                "password varchar(45) NOT NULL);";
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }


        public IEnumerable<UserModel> GetAllUsers()
        {
            List<UserModel> resultado = new List<UserModel>();

            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            string sql = "SELECT * FROM users";

            using (var cmd = new NpgsqlCommand(sql , conn)) 
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var u = reader.GetString(0);
                    var email = reader.GetString(1);
                    var pwd = reader.GetString(2);
                    var user = new UserModel(UserName: u, Email: email, Password: pwd);
                    resultado.Add(user);
                }
            }    
            return resultado;
        }

        public UserModel? GetUserByUserName(string u)
        {
            return GetAllUsers().FirstOrDefault(userModel => userModel.UserName == u);
        }

        public void AddUser(UserModel user )
        {

            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            string sql = "INSERT INTO users (username,email,password) VALUES (@username, @email, @password);";
            var cmd = new NpgsqlCommand( sql, conn)
            {
                Parameters =
                {
                    new("username", user.UserName),
                    new("email", user.Email),
                    new("password", user.Password)
                }
            };

            cmd.ExecuteNonQuery();
        }



    }
}
