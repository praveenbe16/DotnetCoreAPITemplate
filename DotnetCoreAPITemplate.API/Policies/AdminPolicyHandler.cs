using Microsoft.AspNetCore.Authorization;

namespace DotnetCoreAPITemplate.API.Policies
{
    public class AdminPolicyRequirement : IAuthorizationRequirement
    {
        public string RequiredRole { get; }

        public AdminPolicyRequirement(string requiredRole)
        {
            RequiredRole = requiredRole;
        }
    }

    public class AdminPolicyHandler : AuthorizationHandler<AdminPolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminPolicyRequirement requirement)
        {
            if (context.User.IsInRole(requirement.RequiredRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
