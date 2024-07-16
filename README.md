# Blazor Workers Benchmarks

This is a project for comparing the performance of 3 different libraries that enable us to execute .NET code in the background of a Blazor WASM application using Web Workers.

The libraries are:

1. [Tewr.BlazorWorke](https://github.com/Tewr/BlazorWorker)
2. [SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS?tab=readme-ov-file#spawndevblazorjswebworkers)
3. [KristofferStrube.Blazor.WebWorkers](https://github.com/KristofferStrube/Blazor.WebWorkers)

## Notes on the comparisons
These comparisons might be biased as I'm the author of the last of the three libraries.

If you have any ways that I can configure the other worker libraries to achieve better performance for them then please add an issue on the repository.