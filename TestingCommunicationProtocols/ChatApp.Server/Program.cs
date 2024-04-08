using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors( options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapPost("/api/chat/",(Message message)=>
{
    MessagesManager.Messages.Add(message);
    System.Console.WriteLine("reviceing : " + message.Text);
    return Results.Ok();
});

app.MapGet("/api/chat/", async (HttpResponse response) => 
{
    response.Headers.Add("Content-Type", "text/event-stream");

    var numOfMessages = 0;

    while(true)
    {
        if(numOfMessages < MessagesManager.Messages.Count)
        {
            var messages = MessagesManager.Messages.Skip(numOfMessages);
        
            var messagesAsString = JsonSerializer.Serialize(messages);
            numOfMessages = MessagesManager.Messages.Count();
            
            System.Console.WriteLine("sending : " + messagesAsString);
            await response.WriteAsync($"data: {messagesAsString}\n\n");
            await response.Body.FlushAsync();
        }
        await Task.Delay(1000);
    }
});

app.Run();

class MessagesManager
{
    public static List<Message> Messages { get; set; } = [];
}
record Message(string Name, string Text);