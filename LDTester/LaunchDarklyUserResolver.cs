using Aya.FeatureFlagService.LaunchDarkly;
using LaunchDarkly.Sdk;

namespace LDTester;

public class LaunchDarklyUserResolver(ICoreIdentityService coreIdentityService) : ILaunchDarklyUserResolver
{
    public Context CurrentUser()
    {
        var ldUser = coreIdentityService.IsAuthenticated ? coreIdentityService.GetLaunchDarklyUser() : Context.Builder("anonymous").Anonymous(true).Build();
        return ldUser;
    }
}