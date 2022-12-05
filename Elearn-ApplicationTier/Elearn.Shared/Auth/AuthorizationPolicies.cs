using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("SecurityLevel4", a =>
                a.RequireAuthenticatedUser().RequireClaim("SecurityLevel", "4", "5"));

            options.AddPolicy("MustBeTeacher", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "Teacher"));
            options.AddPolicy("MustBeStudent", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "Student"));
            options.AddPolicy("MustBeModerator", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "Moderator"));

            options.AddPolicy("SecurityLevel2OrAbove", a =>
                a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim? levelClaim = context.User.FindFirst(claim => claim.Type.Equals("SecurityLevel"));
                    if (levelClaim == null) return false;
                    return int.Parse(levelClaim.Value) >= 2;
                }));
        });
    }
}