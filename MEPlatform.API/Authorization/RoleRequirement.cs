using MEPlatform.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace MEPlatform.API.Authorization;

public class RoleRequirement : IAuthorizationRequirement
{
    public UserRole[] AllowedRoles { get; }
    
    public RoleRequirement(params UserRole[] allowedRoles)
    {
        AllowedRoles = allowedRoles;
    }
}