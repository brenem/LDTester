namespace LDTester;

public class FlagTest
{
    public List<string> FlagKeys { get; set; }
    public List<TestUser> TestUsers { get; set; }
}

public class TestUser
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public bool ExpectedResult { get; set; }
    
    public override string ToString() => $"{UserId}, {UserName}, {UserEmail}";
}