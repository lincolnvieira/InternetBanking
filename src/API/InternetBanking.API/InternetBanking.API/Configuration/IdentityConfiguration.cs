using InternetBanking.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InternetBankingDatabase")));


            return services;
        }

    }
}
