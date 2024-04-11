using System.Text.Json;
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
    public async Task SendMessage(string messageAsJson)
    {
        System.Console.WriteLine("received : " + messageAsJson);
        var messageData = JsonSerializer.Deserialize<object>(messageAsJson);
        
        await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveMessage", messageAsJson);
    }
}

record MessageData(string RoomName,string UserName, string Message);