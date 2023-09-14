namespace AsyncAwaitDemo3;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        await WriteFileAsync(3, "Hello");
        
    }
    

    private Task WriteFileAsync(int num, string content)
    {
        switch (num)
        {
            case 1:
                return File.WriteAllTextAsync("", content);
            case 2:
                return File.WriteAllTextAsync("", content);
            default:
                return Task.CompletedTask;
        }
    }
    private Task<string> ReadFileAsync(int num)
    {
        switch (num)
        {
            case 1:
                return File.ReadAllTextAsync("");
            case 2:
                return File.ReadAllTextAsync("");
            default:
                return Task.FromResult("Hello");
        }
    }
}