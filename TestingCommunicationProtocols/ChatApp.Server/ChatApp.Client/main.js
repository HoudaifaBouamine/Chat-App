// Function to send message
function SendMessage(name,message) {
    // Implementation of sending message to the server or another client
    console.log("Message sent:", message , ", by ", name);
    
    fetch('http://localhost:5078/api/chat',
    {
      method: "POST",
      body: JSON.stringify({
        text: message,
        name: name,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8"
      }
    })
    .then(response => 
    {
      if(!response.ok) {
        throw new Error('failed to send message');
      }
    });
  
  }
  
  // Function to show messages
  function ShowMessages(messages) {
    const chatWindow = document.getElementById('chat-window');
    chatWindow.innerHTML = ''; // Clear existing messages
  
    messages.forEach(message => {
      const messageElement = document.createElement('div');
      messageElement.textContent = message;
      chatWindow.appendChild(messageElement);
    });
  }
  
  // Function to append messages
  function AppendMessages(messages) {
    const chatWindow = document.getElementById('chat-window');
  
    messages.forEach(message => {

      const messageElement = document.createElement('div');
      messageElement.textContent = message.Name + ": " + message.Text;
      chatWindow.appendChild(messageElement);
    });
  }

  function AppendMessage(message) {
    const chatWindow = document.getElementById('chat-window');
  
    const messageElement = document.createElement('div');
    messageElement.textContent = message;
    chatWindow.appendChild(messageElement);

  }
  
  // Event listener for send button
  document.getElementById('send-button').addEventListener('click', function() {
    const nameInput = document.getElementById('name-input');
    const name = nameInput.value.trim();
    
    const messageInput = document.getElementById('message-input');
    const message = messageInput.value.trim();
    if (message !== '') {
      SendMessage(name,message);
      messageInput.value = ''; // Clear input field after sending message
    }
  });
  
  // Sample usage
  // const initialMessages = ['Hello!', 'How are you?'];
  // ShowMessages(initialMessages);
  

var eventSource = new EventSource("http://localhost:5078/api/chat/");
eventSource.onmessage = function (e) {
  console.log("message received : " + e.data);
  AppendMessages(JSON.parse(e.data));
}