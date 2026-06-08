using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Instantly.ClientUtil.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Soenneker.Extensions.ValueTask;
using System.Threading;
using Soenneker.Extensions.String;
using Soenneker.Instantly.OpenApiClient;
using Soenneker.Instantly.OpenApiClient.Api.V2.Campaigns.Analytics.Overview;
using Soenneker.Instantly.OpenApiClient.Models;

namespace Soenneker.Instantly.Analytics;

/// <inheritdoc cref="IInstantlyAnalyticsUtil"/>
public sealed class InstantlyAnalyticsUtil : IInstantlyAnalyticsUtil
{
    private readonly IInstantlyOpenApiClientUtil _instantlyOpenApiClientUtil;
    private readonly ILogger<InstantlyAnalyticsUtil> _logger;

    private readonly bool _log;

    public InstantlyAnalyticsUtil(IInstantlyOpenApiClientUtil instantlyOpenApiClientUtil, ILogger<InstantlyAnalyticsUtil> logger, IConfiguration config)
    {
        _instantlyOpenApiClientUtil = instantlyOpenApiClientUtil;
        _logger = logger;
        _log = config.GetValue<bool>("Instantly:LogEnabled");
    }

    public async ValueTask<GetCampaignAnalytics200ResponseResponseJsonItem?> GetCampaignCount(string campaignId, DateTimeOffset startAt,
        DateTimeOffset? endAt = null, CancellationToken cancellationToken = default)
    {
        List<GetCampaignAnalytics200ResponseResponseJsonItem>? response =
            await FetchCampaignCounts(campaignId, startAt, endAt, cancellationToken)
                .NoSync();

        return response?.FirstOrDefault();
    }

    public ValueTask<List<GetCampaignAnalytics200ResponseResponseJsonItem>?> GetCampaignsCounts(DateTimeOffset startAt,
        DateTimeOffset? endAt = null, CancellationToken cancellationToken = default)
    {
        return FetchCampaignCounts(null, startAt, endAt, cancellationToken);
    }

    private async ValueTask<List<GetCampaignAnalytics200ResponseResponseJsonItem>?> FetchCampaignCounts(string? campaignId,
        DateTimeOffset startAt, DateTimeOffset? endAt = null, CancellationToken cancellationToken = default)
    {
        InstantlyOpenApiClient client = await _instantlyOpenApiClientUtil.Get(cancellationToken)
                                                                         .NoSync();

        return await new ValueTask<List<GetCampaignAnalytics200ResponseResponseJsonItem>?>(client.Api.V2.Campaigns.Analytics.GetAsync(
            config =>
            {
                config.QueryParameters.StartDate = startAt.ToString("yyyy-MM-dd");
                if (endAt != null)
                    config.QueryParameters.EndDate = endAt.Value.ToString("yyyy-MM-dd");
                if (!campaignId.IsNullOrEmpty())
                    config.QueryParameters.Id = Guid.Parse(campaignId);
            }, cancellationToken)).NoSync();
    }

    public async ValueTask<GetCampaignAnalyticsOverview200Response?> GetCampaignSummary(string campaignId, CancellationToken cancellationToken = default)
    {
        InstantlyOpenApiClient client = await _instantlyOpenApiClientUtil.Get(cancellationToken)
                                                                         .NoSync();

        return await new ValueTask<GetCampaignAnalyticsOverview200Response?>(client.Api.V2.Campaigns.Analytics.Overview.GetAsync(config =>
        {
            config.QueryParameters.Id = Guid.Parse(campaignId);
        }, cancellationToken)).NoSync();
    }
}
