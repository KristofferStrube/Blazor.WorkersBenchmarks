addEventListener("message", e => {
    let input = e.data;

    let result = work(input);

    postMessage(result)
});

function work(input) {
    let sum = 0;
    for (let i = 0; i < input; i++) {
        if (i % 2 == 0) {
            sum += i;
        }
    }
    return 42;
}