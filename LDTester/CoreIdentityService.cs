using LaunchDarkly.Sdk;

namespace LDTester;

public interface ICoreIdentityService
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    bool IsAuthenticated { get; }
    
    Context GetLaunchDarklyUser();
}

public class CoreIdentityService : ICoreIdentityService
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    
    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(UserId) || !string.IsNullOrWhiteSpace(UserName) || !string.IsNullOrWhiteSpace(UserEmail);
    
    public Context GetLaunchDarklyUser()
    {
        if (string.IsNullOrWhiteSpace(UserId))
        {
            return Context.Builder("anonymous").Anonymous(true).Build();
        }
        else
        {
            var userBuilder = Context.Builder(UserId).Anonymous(false);
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                userBuilder = userBuilder.Name(UserName);
            }
            
            if (!string.IsNullOrWhiteSpace(UserEmail))
            {
                userBuilder = userBuilder.Set("email", UserEmail);
            }

            return userBuilder.Build();
        }
    }
}