using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(o=>
{
    o.AddPolicy("AllowAll",p=>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.WithOrigins("http://localhost:3000","https://localhost:3000","http://127.0.0.1:5500","https://teamuptest.netlify.app");
        p.AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapGet("/", () => "Hello World!");

app.MapHub<ChatHub>("/ChatHub");

app.Run("http://localhost:5000");

class ChatHub : Hub
{
    private static ConcurrentDictionary<string, string> Users = new();
    // public async Task SendMessage(string messageAsJson)
    // {
    //     System.Console.WriteLine("received : " + messageAsJson);
    //     var messageData = JsonSerializer.Deserialize<object>(messageAsJson);
        
    //     await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveMessage", messageAsJson);
    // }

    public async Task JoinRoom(string roomName,string userName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

        await Clients.Group(roomName).SendAsync("ReceiveMessage", "",$"{userName} has joined the room" );
        Users[Context.ConnectionId] = userName;
        
        System.Console.WriteLine($"joined room [{roomName}] from [{userName}]");
    }

    public async Task SendMessageToRoom(string roomName,string message)
    {
        var userName = Users[Context.ConnectionId];
        await Clients.Groups(roomName).SendAsync("ReceiveMessage", userName,message);
        System.Console.WriteLine($"sent to room [{roomName}] from [{userName}] : [{message}]");
    }
}

record MessageData(string RoomName,string UserName, string Message);

record JoinRoomDto(string RoomName, string UserName);