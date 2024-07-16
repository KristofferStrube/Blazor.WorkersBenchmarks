using KristofferStrube.Blazor.WebWorkers;

public class MultiplyByTwoJob : JsonJob<double, double>
{
    public override double Work(double input)
    {
        return input * 2;
    }
}