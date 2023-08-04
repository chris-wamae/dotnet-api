using dotnet_api.Data;
using Microsoft.AspNetCore.Identity;

namespace dotnet_api.ServiceExtensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
        }

    }

}
