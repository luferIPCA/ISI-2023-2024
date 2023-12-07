using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace WebApplicationCoreAPIAuthAula.Models
{
    public record class UserModel (
     string UserName, 
     string Email, 
     string Password );
   
}
