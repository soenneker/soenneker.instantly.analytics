using Soenneker.Instantly.Analytics.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics.Contracts;

namespace Soenneker.Instantly.Analytics.Abstract;

/// <summary>
/// A .NET typesafe implementation of Instantly.ai's Analytics API
/// </summary>
public interface IInstantlyAnalyticsUtil
{
    /// <summary>
    /// Retrieves the analytics data for a specific campaign.
    /// </summary>
    /// <param name="campaignId">The unique identifier of the campaign to fetch analytics for.</param>
    /// <param name="startAt">The start date for filtering analytics data.</param>
    /// <param name="endAt">The optional end date for filtering analytics data. If null, data is fetched up to the current date.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, with the result being an instance of 
    /// <see cref="InstantlyAnalyticsCampaignResponseItem"/> if the campaign exists, or <c>null</c> if no data is found.
    /// </returns>
    [Pure]
    ValueTask<InstantlyAnalyticsCampaignResponseItem?> GetCampaignCount(string campaignId, DateTime startAt, DateTime? endAt = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves analytics data for all campaigns within a specified date range.
    /// </summary>
    /// <param name="startAt">The start date for filtering analytics data.</param>
    /// <param name="endAt">The optional end date for filtering analytics data. If null, data is fetched up to the current date.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, with the result being a list of 
    /// <see cref="InstantlyAnalyticsCampaignResponseItem"/> instances, or <c>null</c> if no data is found.
    /// </returns>
    [Pure]
    ValueTask<List<InstantlyAnalyticsCampaignResponseItem>?> GetCampaignsCounts(DateTime startAt, DateTime? endAt = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a summary of analytics data for a specific campaign.
    /// </summary>
    /// <param name="campaignId">The unique identifier of the campaign to fetch the summary for.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, with the result being an instance of 
    /// <see cref="InstantlyAnalyticsCampaignSummaryResponse"/>, or <c>null</c> if no summary is found.
    /// </returns>
    [Pure]
    ValueTask<InstantlyAnalyticsCampaignSummaryResponse?> GetCampaignSummary(string campaignId, CancellationToken cancellationToken = default);
}