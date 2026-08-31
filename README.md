[![](https://img.shields.io/nuget/v/soenneker.instantly.analytics.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.analytics/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.analytics/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.analytics/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.instantly.analytics.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.analytics/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.analytics/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.analytics/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Instantly.Analytics

Retrieve campaign metrics for one campaign or the entire Instantly workspace, plus a campaign overview.

## Install

```bash
dotnet add package Soenneker.Instantly.Analytics
```

## Configure and register

```json
{
  "Instantly": {
    "ApiKey": "<API key>"
  }
}
```

```csharp
using Soenneker.Instantly.Analytics.Registrars;

services.AddInstantlyAnalyticsUtilAsScoped();
```

The scoped analytics service deliberately uses the singleton generated-client provider. Use `AddInstantlyAnalyticsUtilAsSingleton()` when the operation layer should also live for the application lifetime.

## Campaign metrics

```csharp
using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Instantly.OpenApiClient.Models;

GetCampaignAnalytics200ResponseSchemaItem? metrics =
    await analytics.GetCampaignCount(
        campaignId,
        startAt: new DateTimeOffset(2026, 8, 1, 0, 0, 0, TimeSpan.Zero),
        endAt: new DateTimeOffset(2026, 8, 31, 0, 0, 0, TimeSpan.Zero),
        cancellationToken: cancellationToken);
```

Dates are sent as `yyyy-MM-dd`. `GetCampaignCount` returns the first analytics row for the requested campaign, or `null` when the API returns no rows.

## All campaign metrics

```csharp
List<GetCampaignAnalytics200ResponseSchemaItem>? metrics =
    await analytics.GetCampaignsCounts(
        startAt,
        endAt,
        cancellationToken);
```

Omit `endAt` to let Instantly use its current-date behavior.

## Campaign overview

```csharp
GetCampaignAnalyticsOverview200Response? overview =
    await analytics.GetCampaignSummary(
        campaignId,
        cancellationToken);
```

API and deserialization failures are surfaced to the caller; nullable results indicate that Instantly returned no response body or no analytics row.
