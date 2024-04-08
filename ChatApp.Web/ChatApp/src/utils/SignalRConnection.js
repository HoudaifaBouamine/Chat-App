import { useEffect } from 'react';
import * as signalR from '@microsoft/signalr';

function SignalRConnection(setMessages) {
  const connection = new signalR.HubConnectionBuilder()
    .withAutomaticReconnect()
    .withUrl("http://localhost:5008/chatHub")
    .build();

  useEffect(() => {
    connection.start()
      .then(() => {
        console.log('SignalR connected.');
      })
      .catch(error => console.error('SignalR connection failed: ', error));

    connection.on("ReceiveMessage", (message) => {
        console.log("recived : " + message);
      setMessages(prevMessages => [...prevMessages, message]);
    });

    return () => {
      connection.stop();
    };
  }, [connection, setMessages]);

  return connection;
}

export default SignalRConnection;
