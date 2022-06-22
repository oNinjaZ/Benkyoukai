using Benkyoukai.Application.Common.Interfaces.Authentication;
using Benkyoukai.Application.Common.Interfaces.Services;
using Benkyoukai.Infrastructure.Authentication;
using Benkyoukai.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Benkyoukai.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}