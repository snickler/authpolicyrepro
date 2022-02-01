using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Security.Principal;

namespace authrepro
{
    public class SomeAuthHandler : AuthorizationHandler<SomeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SomeRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext ctx)
            {
                if (ctx.HttpContext.User is WindowsPrincipal)
                    context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
