using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Instantly.Client.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.Object;
using Soenneker.Instantly.Analytics.Requests;
using System;
using Soenneker.Instantly.Analytics.Responses;
using System.Linq;
using Soenneker.Extensions.ValueTask;
using System.Threading;
using Soenneker.Extensions.String;

namespace Soenneker.Instantly.Analytics;

/// <inheritdoc cref="IInstantlyAnalyticsUtil"/>
public class InstantlyAnalyticsUtil : IInstantlyAnalyticsUtil
{
    private readonly IInstantlyClient _instantlyClient;
    private readonly ILogger<InstantlyAnalyticsUtil> _logger;

    private readonly string _apiKey;
    private readonly bool _log;

    public InstantlyAnalyticsUtil(IInstantlyClient instantlyClient, ILogger<InstantlyAnalyticsUtil> logger, IConfiguration config)
    {
        _instantlyClient = instantlyClient;
        _logger = logger;

        _apiKey = config.GetValueStrict<string>("Instantly:ApiKey");
        _log = config.GetValue<bool>("Instantly:LogEnabled");
    }

    public async ValueTask<InstantlyAnalyticsCampaignResponseItem?> GetCampaignCount(string campaignId, DateTime startAt, DateTime? endAt = null, CancellationToken cancellationToken = default)
    {
        List<InstantlyAnalyticsCampaignResponseItem>? response = await FetchCampaignCounts(campaignId, startAt, endAt, cancellationToken).NoSync();
        return response?.FirstOrDefault();
    }

    public ValueTask<List<InstantlyAnalyticsCampaignResponseItem>?> GetCampaignsCounts(DateTime startAt, DateTime? endAt = null, CancellationToken cancellationToken = default)
    {
        return FetchCampaignCounts(null, startAt, endAt, cancellationToken);
    }

    private async ValueTask<List<InstantlyAnalyticsCampaignResponseItem>?> FetchCampaignCounts(string? campaignId, DateTime startAt, DateTime? endAt = null,
        CancellationToken cancellationToken = default)
    {
        HttpClient client = await _instantlyClient.Get(cancellationToken).NoSync();

        var request = new InstantlyAnalyticsRequest
        {
            ApiKey = _apiKey,
            StartDate = startAt.ToString("MM-dd-yyyy")
        };

        if (!campaignId.IsNullOrEmpty())
            request.CampaignId = campaignId;

        if (endAt != null)
            request.EndDate = endAt.Value.ToString("MM-dd-yyyy");

        string uri = "analytics/campaign/count" + request.ToQueryString();

        return await client.SendToType<List<InstantlyAnalyticsCampaignResponseItem>>(uri, _logger, cancellationToken: cancellationToken).NoSync();
    }

    public async ValueTask<InstantlyAnalyticsCampaignSummaryResponse?> GetCampaignSummary(string campaignId, CancellationToken cancellationToken = default)
    {
        HttpClient client = await _instantlyClient.Get(cancellationToken).NoSync();

        var request = new InstantlyAnalyticsRequest
        {
            ApiKey = _apiKey,
            CampaignId = campaignId
        };

        string uri = "analytics/campaign/summary" + request.ToQueryString();

        return await client.SendToType<InstantlyAnalyticsCampaignSummaryResponse>(uri, _logger, cancellationToken: cancellationToken).NoSync();
    }
}