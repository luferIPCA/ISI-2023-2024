using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplicationCoreAPIAuthAula.Models
{
    public class UserRegisterDTO    {
        [Required]
        [MaxLength(20)]
        [property: JsonPropertyName("username")] 
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        [property: JsonPropertyName("email")]
        public string Email { get; set; }


        [Required]
        [MaxLength(30)]
        [property: JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
