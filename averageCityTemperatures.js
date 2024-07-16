addEventListener("message", async e => {
    let input = e.data;

    let result = await work(input);

    postMessage(result)
});

const measurementsEndpoint = "https://kristoffer-strube.dk/API/temperature/"

let responseAsText = undefined;

async function work(input) {
    if (responseAsText == undefined) {
        let response = await fetch(measurementsEndpoint + input);
        responseAsText = await response.text();
    }
    
    let aggregates = new Map();

    for (line of responseAsText.split('\n')) {
        let parts = line.split(';');
        let city = parts[0];
        let temperature = parseFloat(parts[1]);

        let aggregate = aggregates.get(city);
        if (aggregate == undefined) {
            aggregate = { min: Number.MAX_VALUE, max: -Number.MAX_VALUE, sum: 0, count: 0 };
            aggregates.set(city, aggregate);
        }
        aggregate.min = temperature < aggregate.min ? temperature : aggregate.min;
        aggregate.max = temperature > aggregate.max ? temperature : aggregate.max;
        aggregate.sum += temperature;
        aggregate.count++;
    }

    let result = [];

    aggregates.forEach((aggregate, city) => {
        result.push({
            city: city,
            minTemperature: aggregate.min,
            averageTemperature: Math.round((aggregate.sum / aggregate.count + Number.EPSILON) * 10) / 10,
            maxTemperature: aggregate.max,
        })
    })

    return result;
}