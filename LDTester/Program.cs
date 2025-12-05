// See https://aka.ms/new-console-template for more information

using FeatureManagement;
using LaunchDarkly.OpenFeature.ServerProvider;
using LaunchDarkly.Sdk.Server;
using Microsoft.Extensions.DependencyInjection;
using OpenFeature.Model;

var userKey = "anonymous";
var userEmail = "";
var flagKey = "job-importer-optionally-omit-shift-changes";

IServiceCollection services = new ServiceCollection();

await services.AddFeatureManagementAsync(() =>
{
    var sdkKey = "sdk-0ed8a92c-fc76-4582-ae0c-66b0eb3a70a1";
    var config = Configuration.Builder(sdkKey).Build();
    var ldProvider = new Provider(config);
    return ldProvider;
});

var sp = services.BuildServiceProvider();

var featureFlagClient = sp.GetRequiredService<IFeatureFlagClient>();

var context = EvaluationContext.Builder()
    .SetTargetingKey(userKey)
    //.Name(userEmail)
    // .Set("email", userEmail)
    .Build();

var enabled = await featureFlagClient.GetBooleanValue(flagKey, false, context);

Console.WriteLine($"Flag is enabled: {enabled}");
