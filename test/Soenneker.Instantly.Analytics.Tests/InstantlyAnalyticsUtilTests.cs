using Soenneker.Instantly.Analytics.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Instantly.Analytics.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class InstantlyAnalyticsUtilTests : HostedUnitTest
{
    private readonly IInstantlyAnalyticsUtil _util;

    public InstantlyAnalyticsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IInstantlyAnalyticsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
