using Aya.FeatureFlagService;
using Microsoft.Extensions.Options;

namespace LDTester;

public class Worker(ILogger<Worker> logger, ICoreIdentityService coreIdentityService, IFeatureFlagService featureFlagService, IOptions<FlagTest> flagTest) : BackgroundService
{
    private readonly FlagTest _flagTest = flagTest.Value;
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            foreach (var flagKey in _flagTest.FlagKeys)
            {
                foreach (var user in _flagTest.TestUsers)
                {
                    coreIdentityService.UserId = user.UserId;
                    coreIdentityService.UserName = user.UserName;
                    coreIdentityService.UserEmail = user.UserEmail;

                    var enabled = featureFlagService.IsEnabled(flagKey);

                    if (user.ExpectedResult == enabled)
                        logger.LogInformation("Feature flag {flagKey} is {enabled} for user {user}", flagKey, enabled, user.ToString());
                    else
                        logger.LogError("Feature flag {flagKey} is {enabled} for user {user} but expected result is {expectedResult}", flagKey, enabled, user.ToString(), user.ExpectedResult.ToString());
                }
            }

            return Task.CompletedTask;
        }
        catch (Exception exception)
        {
            return Task.FromException(exception);
        }
    }
}