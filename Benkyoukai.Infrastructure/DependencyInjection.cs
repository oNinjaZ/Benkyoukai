using Benkyoukai.Application.Common.Interfaces.Authentication;
using Benkyoukai.Application.Common.Interfaces.Persistence;
using Benkyoukai.Application.Common.Interfaces.Services;
using Benkyoukai.Infrastructure.Authentication;
using Benkyoukai.Infrastructure.Persistence;
using Benkyoukai.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Benkyoukai.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}