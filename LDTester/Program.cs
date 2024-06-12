// See https://aka.ms/new-console-template for more information

using FeatureManagement;
using LaunchDarkly.OpenFeature.ServerProvider;
using LaunchDarkly.Sdk.Server;
using Microsoft.Extensions.DependencyInjection;
using OpenFeature.Model;

var userKey = "";
var userEmail = "";
var flagKey = "";

IServiceCollection services = new ServiceCollection();

await services.AddFeatureManagementAsync(() =>
{
    var sdkKey = "";
    var config = Configuration.Builder(sdkKey).Build();
    var ldProvider = new Provider(config);
    return ldProvider;
});

var sp = services.BuildServiceProvider();

var featureFlagClient = sp.GetRequiredService<IFeatureFlagClient>();

var userContext = EvaluationContext.Builder()
    .SetTargetingKey(userKey)
    //.Name(userEmail)
    .Set("email", userEmail)
    .Build();

var enabled = await featureFlagClient.GetBooleanValue(flagKey, false, userContext);

Console.WriteLine($"Flag is enabled: {enabled}");
