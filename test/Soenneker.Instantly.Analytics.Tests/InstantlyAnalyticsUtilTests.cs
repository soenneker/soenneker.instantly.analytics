using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Instantly.Analytics.Tests;

[Collection("Collection")]
public class InstantlyAnalyticsUtilTests : FixturedUnitTest
{
    private readonly IInstantlyAnalyticsUtil _util;

    public InstantlyAnalyticsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IInstantlyAnalyticsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
