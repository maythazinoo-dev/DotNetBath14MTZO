using DotNetBath14MTZO.Emoji.MinimalApi.Feautres;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EmojiEFCoreService emojiEFCoreService = new EmojiEFCoreService();
//await emojiEFCoreService.SavingDataAsync();


app.MapGet("/api/Emojis", async() =>
{
    
        var list = await emojiEFCoreService.GetEmojiAsync();
        return Results.Ok(list);
  
})
 .WithName("GetAllEmojis")
 .WithOpenApi();


app.MapGet("/api/Emoji/{id}", async (int id) =>
{
    var item = await emojiEFCoreService.GetEmojiByIdAsync(id);
    if (!item.IsSuccess)
    {
        return Results.NotFound("Data not found");
    }
    return Results.Ok(item);
})
 .WithName("GetByIdEmojis")
 .WithOpenApi();


app.MapGet("/api/Emoji/FilterByName",async (string name) =>
{
    var item =await emojiEFCoreService.FilterByName(name);
    return Results.Ok(item);
})
   .WithName("FilterByName")
 .WithOpenApi();
app.Run();
