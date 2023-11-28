/*
 * lufer
 * ISI
 * See https://dotnetcorecentral.com/blog/asp-net-core-authorization/
 * */
using Microsoft.AspNetCore.Authorization;
using RESTAuth.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RESTAuth
{
    public class AuthorizedRequirement : IAuthorizationRequirement
    {
        public AuthorizedRequirement()
        {
        }
    }

    public class AuthorizedRequirementHandler : AuthorizationHandler<AuthorizedRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizedRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == ClaimTypes.Email))
                return Task.CompletedTask;

            var emailAddress = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            if (Users.users.Any(x => x.EmailAddress == emailAddress))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

   
}