using MEPlatform.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace MEPlatform.API.Authorization;

public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        var userRole = context.User.FindFirst("role")?.Value;
        
        if (userRole != null && Enum.TryParse<UserRole>(userRole, out var role))
        {
            if (requirement.AllowedRoles.Contains(role))
            {
                context.Succeed(requirement);
            }
        }
        
        return Task.CompletedTask;
    }
}