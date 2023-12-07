

using WebApplicationCoreAPIAuthAula.Models;

namespace WebApplicationCoreAPIAuthAula.Data
{
    public class UserRepositoryData
    {
        private readonly string _connStr;

        public UserRepositoryData( string connectionString)
        {
            _connStr = connectionString ;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            List<UserModel> resultado = new List<UserModel>();
            resultado.Add(
            new UserModel(
                UserName: "user01",
                Email: "user01@mail.com",
                Password: "123"
            ));
            resultado.Add( new UserModel(
                UserName: "user02",
                Email: "user02@mail.com",
                Password: "234"
            ));
            return resultado;
        }

        public UserModel? GetUserByUserName(string u)
        {
            return GetAllUsers().FirstOrDefault(userModel => userModel.UserName == u);
        }



        
    }
}
