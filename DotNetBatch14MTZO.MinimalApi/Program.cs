using DotNetBatch14MTZO.MinimalApi.Endpoints;
using DotNetBath14MTZO.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

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
//.WithOpenApi();

//app.MapGet("/api/blogs", () =>
//{

//    BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
//    var model = blogEfCoreService.GetBlogs();
//    return Results.Ok(model);
//})
//.WithName("GetBlogs")
//.WithOpenApi();

//app.MapGet("/api/blogs/{id}", (string id) => {
//    BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
//    var model = blogEfCoreService.GetBlog(id);
//    return Results.Ok(model);
//})
//.WithName("GetBlog")
//.WithOpenApi();

//app.MapPost("/api/blogs", (BlogModel requestModel) => {
//    BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
//    var model = blogEfCoreService.CreateBlog(requestModel);
//    return Results.Ok(model);
//})
//.WithName("CreateBlog")
//.WithOpenApi();

//app.MapPatch("/api/blogs/{id}", (string id, BlogModel requestModel) =>
//{
//    requestModel.BlogId = id;
//    BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
//    var model = blogEfCoreService.UpdateBlog(requestModel);
//    return Results.Ok(model);
//})
//.WithName("UpdateBlog")
//.WithOpenApi();

//app.MapPut("/api/blogs/{id}", (string id,BlogModel requestModel) =>
//{
//    requestModel.BlogId = id;
//    BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
//    var model = blogEfCoreService.UpsertBlog(requestModel);
//    return Results.Ok(model);

//})
//.WithName("UpsertBlog")
//.WithOpenApi();

//app.MapDelete("/api/blogs/{id}", (string id) =>
//{
//    BlogEfCoreService blogEfCoreService= new BlogEfCoreService();
//    var model = blogEfCoreService.DeleteBlog(id);
//    return Results.Ok(model);
//})
//.WithName("DeleteBlog")
//.WithOpenApi();
app.UseBlogEndpoints();
app.Run();

