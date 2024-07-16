using Blazor.WorkersBenchmarks;
using BlazorWorker.Core;
using KristofferStrube.Blazor.WebWorkers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Tewr
builder.Services.AddWorkerFactory();

// SpawnDev
builder.Services.AddBlazorJSRuntime();
builder.Services.AddWebWorkerService();
builder.Services.AddSingleton<IMathService, MathService>();

builder.Services.AddSingleton<JsonJob<string, int>, StringSumJob>();
builder.Services.AddSingleton<JsonJob<string, int>, LargeInputJob>();
builder.Services.AddSingleton<JsonJob<int, int>, SumEvenNumbersJob>();
builder.Services.AddSingleton<TaskJsonJob<int, CityStatistics[]>, AverageCityTemperaturesJob>();

await builder.Build().BlazorJSRunAsync();

public interface IMathService
{
    public double MutliplyByTwo(double input);
}

public class MathService : IMathService
{
    public double MutliplyByTwo(double input)
    {
        return input * 2;
    }
}
