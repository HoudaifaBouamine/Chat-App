// signalr-client.js

function createSignalrClient() {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5000/ChatHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    function start() {
        return new Promise((resolve, reject) => {
            connection.start()
                .then(() => {
                    console.log("SignalR Connected.");
                    resolve();
                })
                .catch(error => {
                    console.error("Error starting SignalR connection:", error);
                    reject(error);
                });
        });
    }

    function sendMessage(message) {
        return new Promise((resolve, reject) => {
            connection.invoke("SendMessage", message)
                .then(() => {
                    resolve();
                })
                .catch(error => {
                    console.error("Error sending message:", error);
                    reject(error);
                });
        });
    }

    function receiveMessageCallback(callback) {
        connection.on("ReceiveMessage", (message) => {
            callback(message);
        });
    }

    return {
        start: start,
        sendMessage: sendMessage,
        receiveMessageCallback: receiveMessageCallback
    };
}
