using Soenneker.Instantly.Analytics.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Soenneker.Instantly.Analytics.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Analytics API
/// </summary>
public interface IInstantlyAnalyticsUtil
{
    ValueTask<InstantlyAnalyticsCampaignResponseItem?> GetCampaignCount(string campaignId, DateTime startAt, DateTime? endAt = null, CancellationToken cancellationToken = default);

    ValueTask<List<InstantlyAnalyticsCampaignResponseItem>?> GetCampaignsCounts(DateTime startAt, DateTime? endAt = null, CancellationToken cancellationToken = default);
}