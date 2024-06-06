using Microsoft.AspNetCore.Identity;

namespace App1.Repositories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}