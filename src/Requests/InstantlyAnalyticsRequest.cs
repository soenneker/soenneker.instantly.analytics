using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Soenneker.Instantly.Analytics.Requests;

internal class InstantlyAnalyticsRequest
{
    [Required]
    [JsonPropertyName("api_key")]
    public string ApiKey { get; set; } = default!;

    [JsonPropertyName("campaign_id")]
    public string? CampaignId { get; set; }

    [Required]
    [JsonPropertyName("start_date")]
    public string StartDate { get; set; } = default!;

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }
}