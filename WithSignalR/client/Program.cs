using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Client is running!");

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5000/ChatHub")
    .Build();

await connection.StartAsync();
await connection.InvokeAsync("SendMessage", "First Message");


connection.On<string>("ReceiveMessage",(message) =>
{
    System.Console.WriteLine("received : " + message);
});

app.MapGet("send",([FromQuery] string message)=>
{
    connection.InvokeAsync("SendMessage",message);
    System.Console.WriteLine("sent : " + message);
});

app.Run();