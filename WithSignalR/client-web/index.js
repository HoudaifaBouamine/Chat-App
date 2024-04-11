const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/ChatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();



try {
    await connection.invoke("SendMessage", "first message");
} catch (err) {
    console.error(err);
}