using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Instantly.Client.Registrars;

namespace Soenneker.Instantly.Analytics.Registrars;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Analytics API
/// </summary>
public static class InstantlyAnalyticsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IInstantlyAnalyticsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddInstantlyAnalyticsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddInstantlyClientAsSingleton();
        services.TryAddSingleton<IInstantlyAnalyticsUtil, InstantlyAnalyticsUtil>();
    }

    /// <summary>
    /// Adds <see cref="IInstantlyAnalyticsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddInstantlyAnalyticsUtilAsScoped(this IServiceCollection services)
    {
        services.AddInstantlyClientAsSingleton();
        services.TryAddScoped<IInstantlyAnalyticsUtil, InstantlyAnalyticsUtil>();
    }
}
