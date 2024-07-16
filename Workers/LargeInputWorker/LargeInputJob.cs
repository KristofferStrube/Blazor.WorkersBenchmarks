using KristofferStrube.Blazor.WebWorkers;

public class LargeInputJob : JsonJob<string, int>
{
    public override int Work(string input)
    {
        return 42;
    }
}