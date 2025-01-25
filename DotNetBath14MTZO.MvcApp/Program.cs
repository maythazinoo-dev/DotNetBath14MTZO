using DotNetBath14MTZO.Dbservice.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy=null);
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
},ServiceLifetime.Transient,ServiceLifetime.Transient);

//builder.Services.AddScoped<BlogEfCoreService>();// Ef Core Service register
//string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
//builder.Services.AddScoped(n => new BlogDapperService(connectionString));
//builder.Services.AddScoped(n => new BlogService(connectionString));

//want to switch services 
//register service
//builder.Services.AddScoped<IBlogService, BlogEfCoreService>();
//builder.Services.AddScoped<IBlogService, BlogDapperService>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
