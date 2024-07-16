using System.Text.Json.Serialization;

public class CityStatistics
{
    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("minTemperature")]
    public required double MinTemperature { get; set; }

    [JsonPropertyName("averageTemperature")]
    public required double AverageTemperature { get; set; }

    [JsonPropertyName("maxTemperature")]
    public required double MaxTemperature { get; set; }
}
