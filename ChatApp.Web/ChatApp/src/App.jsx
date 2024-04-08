import { useState } from 'react';
import SignalRConnection from './utils/SignalRConnection';
import './App.css';

function App() {
  const [messages, setMessages] = useState([]);
  const [inputMessage, setInputMessage] = useState('');
  const connection = SignalRConnection(setMessages);

  const sendMessage = () => {
    if (inputMessage.trim() !== '') {
      connection.invoke("SendMessage", inputMessage);
      setInputMessage('');
    }
  };

  const handleInputChange = (event) => {
    setInputMessage(event.target.value);
  };

  const handleKeyDown = (event) => {
    if (event.key === 'Enter') {
      sendMessage();
    }
  };

  return (
    <div className="app-container">
      <div className="chat-content">
        {messages.map((message, index) => (
          <div key={index}>{message}</div>
        ))}
      </div>
      <div className="chat-input">
        <input
          type="text"
          value={inputMessage}
          onChange={handleInputChange}
          onKeyDown={handleKeyDown}
          placeholder="Type your message..."
        />
        <button onClick={sendMessage}>Send</button>
      </div>
    </div>
  );
}

export default App;
