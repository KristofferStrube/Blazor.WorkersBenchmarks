addEventListener("message", e => {
    let input = e.data;

    let result = work(input);

    postMessage(result)
});

function work(input) {
    return 42;
}