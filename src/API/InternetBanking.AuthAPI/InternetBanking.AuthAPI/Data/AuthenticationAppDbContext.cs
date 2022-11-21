using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.AuthAPI.Data
{
    public class AuthenticationAppDbContext : IdentityDbContext
    {
        public AuthenticationAppDbContext(DbContextOptions<AuthenticationAppDbContext> options) : base(options) { }
    }
}
