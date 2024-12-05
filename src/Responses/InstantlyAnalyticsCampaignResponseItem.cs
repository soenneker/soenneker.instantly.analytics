using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Analytics.Responses;

public record InstantlyAnalyticsCampaignResponseItem
{
    [JsonPropertyName("campaign_id")]
    public string CampaignId { get; set; } = default!;

    [JsonPropertyName("campaign_name")]
    public string CampaignName { get; set; } = default!;

    [JsonPropertyName("total_emails_sent")]
    public int TotalEmailsSent { get; set; } 

    [JsonPropertyName("emails_read")]
    public int? EmailsRead { get; set; } 

    [JsonPropertyName("new_leads_contacted")]
    public int NewLeadsContacted { get; set; } 

    [JsonPropertyName("leads_replied")]
    public int LeadsReplied { get; set; }

    [JsonPropertyName("leads_read")]
    public int? LeadsRead { get; set; }
}