// See https://aka.ms/new-console-template for more information
using Aya.FeatureFlagService;
using Azure.Identity;
using LDTester;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddUserSecrets<Program>();
builder.Logging.AddConsole();

var credential = new DefaultAzureCredential();
var appConfigConnectionString = builder.Configuration.GetConnectionString("AppConfig:Endpoint");

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(new Uri(appConfigConnectionString!), credential)
        .Select(keyFilter: "CoreApi:LaunchDarkly*", labelFilter: "aya-coreapi")
        .Select(keyFilter: "CoreApi:LaunchDarkly*", labelFilter: "aya-coreapi-kv")
        .ConfigureKeyVault(kv => kv.SetCredential(credential))
        .TrimKeyPrefix("CoreApi:");
});
    
var lauchDarklyKey = builder.Configuration.GetValue<string>("LaunchDarkly:Key");

builder.Services.AddSingleton<ICoreIdentityService, CoreIdentityService>();
builder.Services.AddLaunchDarklyFeatureFlagService<LaunchDarklyUserResolver>(lauchDarklyKey!);

builder.Services.AddHostedService<Worker>();

var flagTestSection = builder.Configuration.GetSection("FlagTest");
builder.Services.Configure<FlagTest>(flagTestSection);

var host = builder.Build();
await host.RunAsync();
