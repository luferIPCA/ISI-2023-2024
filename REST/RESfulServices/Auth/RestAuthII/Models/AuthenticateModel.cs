/**
 * lufer
 * ISI - 2023
 * Roules/Authorization
 * */

using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}