using KristofferStrube.Blazor.WebWorkers;

public class SumEvenNumbersJob : JsonJob<int, int>
{
    public override int Work(int input)
    {
        int sum = 0;
        for (int i = 0; i < input; i++)
        {
            if (i % 2 == 0)
            {
                sum += i;
            }
        }
        return sum;
    }
}