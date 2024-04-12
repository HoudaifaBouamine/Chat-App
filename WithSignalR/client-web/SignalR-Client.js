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

    function sendMessage(roomName,message) {
        return new Promise((resolve, reject) => {
            connection.invoke("SendMessageToRoom", roomName,message)
                .then(() => {
                    resolve();
                })
                .catch(error => {
                    console.error("Error sending message:", error);
                    reject(error);
                });
        });
    }

    function JoinRoom(roomName, userName) {
        return new Promise((resolve, reject) => {
            connection.invoke("JoinRoom", roomName,userName)
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
        connection.on("ReceiveMessage", (userName,message) => {
            callback(userName,message);
        });
    }

    return {
        start: start,
        sendMessage: sendMessage,
        receiveMessageCallback: receiveMessageCallback,
        JoinRoom : JoinRoom
    };
}
