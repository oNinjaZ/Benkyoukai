using Benkyoukai.Application.Common.Interfaces.Authentication;
using Benkyoukai.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Benkyoukai.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}