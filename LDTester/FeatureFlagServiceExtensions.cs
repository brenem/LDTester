using Aya.FeatureFlagService;

namespace LDTester;

public static class FeatureFlagServiceExtensions
{
    public static bool IsEnabled(this IFeatureFlagService featureFlagService, string key, FeatureFlagUser featureFlagUser)
    {
        return featureFlagService.IsEnabled(new FeatureFlag(key), featureFlagUser);
    }
}
