namespace xunit_deadlock_example;

public class UnitTest1
{
    [Fact]
    public void Hello_Deadlock()
    {
        // we will get a deadlock, this is the expected behavior, xunit has AsyncTestSyncContext 
        Assert.NotEmpty(GetResultAsync().Result);
    }

    async Task<string> GetResultAsync()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync("https://google.com");
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}