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
    public async Task SendMessage(string message)
    {
        System.Console.WriteLine("received : " + message);
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}