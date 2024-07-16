using KristofferStrube.Blazor.WebWorkers;

public class AverageCityTemperaturesJob(HttpClient httpClient) : TaskJsonJob<int, CityStatistics[]>
{
    private const string MeasurementsEndpoint = "https://kristoffer-strube.dk/API/temperature/";
    private string? responseAsText;

    public override async Task<CityStatistics[]> Work(int input)
    {
        if (responseAsText is null)
        {
            responseAsText = await httpClient.GetStringAsync(MeasurementsEndpoint + input);
        }

        Dictionary<string, CityAggregate> aggregates = [];

        foreach (string line in responseAsText.Split("\n"))
        {
            string[] parts = line.Split(";");
            string city = parts[0];
            float temperature = float.Parse(parts[1]);

            if (!aggregates.TryGetValue(city, out CityAggregate? aggregate))
            {
                aggregate = new();
                aggregates[city] = aggregate;
            }
            aggregate.Min = temperature < aggregate.Min ? temperature : aggregate.Min;
            aggregate.Max = temperature > aggregate.Max ? temperature : aggregate.Max;
            aggregate.Sum += temperature;
            aggregate.Count++;
        }

        List<CityStatistics> result = [];
        foreach ((string city, CityAggregate aggregate) in aggregates)
        {
            result.Add(new()
            {
                City = city,
                MinTemperature = aggregate.Min / 10.0,
                AverageTemperature = Math.Round(aggregate.Sum / 10.0 / aggregate.Count, 1),
                MaxTemperature = aggregate.Max / 10.0
            });
        }

        CityStatistics[] resultAsArray = result.ToArray();

        return resultAsArray;
    }

    private class CityAggregate
    {
        public float Min { get; set; } = float.MaxValue;
        public float Max { get; set; } = float.MinValue;
        public float Sum { get; set; }
        public int Count { get; set; }
    }
}