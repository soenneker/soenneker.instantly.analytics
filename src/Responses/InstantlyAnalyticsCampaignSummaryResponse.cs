using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Analytics.Responses;

using System.Text.Json.Serialization;

public record InstantlyAnalyticsCampaignSummaryResponse
{
    /// <summary>
    /// Unique identifier for the campaign.
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Campaign's name.
    /// </summary>
    [JsonPropertyName("campaign_name")]
    public string? CampaignName { get; set; }

    /// <summary>
    /// Total number of leads.
    /// </summary>
    [JsonPropertyName("total_leads")]
    public int? TotalLeads { get; set; }

    /// <summary>
    /// Number of leads for whom the sequence has started.
    /// </summary>
    [JsonPropertyName("contacted")]
    public int? Contacted { get; set; }

    /// <summary>
    /// Number of leads who have opened at least one email.
    /// </summary>
    [JsonPropertyName("leads_who_read")]
    public int? LeadsWhoRead { get; set; }

    /// <summary>
    /// Number of leads who have replied.
    /// </summary>
    [JsonPropertyName("leads_who_replied")]
    public int? LeadsWhoReplied { get; set; }

    /// <summary>
    /// Number of bounced leads.
    /// </summary>
    [JsonPropertyName("bounced")]
    public int? Bounced { get; set; }

    /// <summary>
    /// Number of unsubscribed leads.
    /// </summary>
    [JsonPropertyName("unsubscribed")]
    public int? Unsubscribed { get; set; }

    /// <summary>
    /// Number of leads for whom the sequence has completed.
    /// </summary>
    [JsonPropertyName("completed")]
    public int? Completed { get; set; }
}
