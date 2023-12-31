using ChatApp.Api.Data;
using ChatApp.Api.Repositories.Implimentations;
using ChatApp.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChatAppDbContext>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/user", () => { 
    
     return Results.Ok (new ChatAppDbContext().Users.ToList()); 

});

app.Run("https://localhost:3000");
