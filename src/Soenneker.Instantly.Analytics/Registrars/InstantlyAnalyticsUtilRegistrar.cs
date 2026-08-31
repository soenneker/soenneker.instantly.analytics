using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Instantly.ClientUtil.Registrars;

namespace Soenneker.Instantly.Analytics.Registrars;

/// <summary>
/// Registers Instantly campaign analytics operations.
/// </summary>
public static class InstantlyAnalyticsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IInstantlyAnalyticsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddInstantlyAnalyticsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddInstantlyOpenApiClientUtilAsSingleton().TryAddSingleton<IInstantlyAnalyticsUtil, InstantlyAnalyticsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IInstantlyAnalyticsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddInstantlyAnalyticsUtilAsScoped(this IServiceCollection services)
    {
        services.AddInstantlyOpenApiClientUtilAsSingleton().TryAddScoped<IInstantlyAnalyticsUtil, InstantlyAnalyticsUtil>();

        return services;
    }
}
