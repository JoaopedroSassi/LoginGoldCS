using LoginGoldCS.Repositories;
using LoginGoldCS.Repositories.Interfaces;
using LoginGoldCS.Services;
using LoginGoldCS.Services.Interfaces;

namespace LoginGoldCS.Extensions;

public static class DependencyInjectionExtension
{
    public static void ConfigureDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<ILoginUserRepository, LoginUserRepository>();

        services.AddScoped<ILoginUserService, LoginUserService>();
    }
}
