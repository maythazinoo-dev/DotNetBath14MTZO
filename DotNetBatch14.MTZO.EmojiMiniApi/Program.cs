var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.PropertyNameCaseInsensitive = false;
//    options.SerializerOptions.PropertyNamingPolicy = null;
//    options.SerializerOptions.WriteIndented = true;
//});// Change Json Policy

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi
//

EmojiResponseModel Response = null;

app.MapGet("/emojis", async () =>
{
    await FetchAsync();
    return Results.Ok(Response!.emojis);
})
.WithName("GetEmojis")
.WithOpenApi();

app.MapGet("/emojis/{name}", async (string name) =>
{
    await FetchAsync();
    var lst = Response!
        .emojis
        .Where(x => x.name.ToLower().Contains(name.ToLower()));
    return Results.Ok(lst);
})
.WithName("GetEmoji")
.WithOpenApi();

async Task FetchAsync()
{
    if (Response is null)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetFromJsonAsync<EmojiResponseModel>("https://gist.githubusercontent.com/oliveratgithub/0bf11a9aff0d6da7b46f1490f86a71eb/raw/d8e4b78cfe66862cf3809443c1dba017f37b61db/emojis.json");
        Response = response!;
    }
}
    app.Run();


public class EmojiResponseModel
{
    public EmojiModel[] emojis { get; set; }
}

public class EmojiModel
{
    public string emoji { get; set; }
    public string name { get; set; }
    public string shortname { get; set; }
    public string unicode { get; set; }
    public string html { get; set; }
    public string category { get; set; }
    public string order { get; set; }
}



