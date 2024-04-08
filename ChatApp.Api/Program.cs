// using ChatApp.Api.Data;
// using ChatApp.Api.Repositories.Implimentations;
// using ChatApp.Api.Repositories.Interfaces;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.AspNetCore.SignalR;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;
// using SignalRSwaggerGen.Attributes;


// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(options =>
// {
//     options.AddSignalRSwaggerGen();
// });

// builder.Services.AddDbContext<ChatAppDbContext>();
// builder.Services.AddScoped<IUserRepository,UserRepository>();
// builder.Services.AddScoped<IMessageRepository, MessageRepository>();

// builder.Services.AddCors(options=>
// {
//      options.AddPolicy("AllowAll",p=>{
//           p.AllowAnyOrigin(); 
//           p.AllowAnyMethod();
//           p.AllowAnyHeader();
//      });
// });

// builder.Services.AddSignalR();

// var app = builder.Build();

// app.MapHub<ChatHub>("/chatHub");

// app.UseCors("AllowAll");


// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapGet("/",()=>
// {
//      return Results.Redirect("/swagger/index.html");
// }).WithTags("Test");



// app.UseSwagger();
// app.UseSwaggerUI();

// app.Run("https://localhost:3000");

// [SignalRHub]
// public class ChatHub : Hub
// {
//     public async Task SendMessage(string message)
//     {
//         await Clients.All.SendAsync("ReceiveMessage", message);
//     }
// }

using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAnyOrigin", p => p
        .AllowAnyOrigin() // Origin of an html file opened in a browser
        .AllowAnyHeader()
        .AllowAnyMethod()); 
});
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors("AllowAnyOrigin");
app.MapHub<ChatHub>("/chatHub");
app.Run("http://localhost:5008/");

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
          System.Console.WriteLine("reviced : " + message);
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}