using Microsoft.EntityFrameworkCore;
using People.People.Core.Services;
using People.People.Core.Services.Interfaces;
using People.People.Infrastructure.Data.Context;
using People.People.Infrastructure.Data.Repositories;
using People.People.Infrastructure.Data.Repositories.Interfaces;
using People.People.Infrastructure.External;
using People.People.Infrastructure.External.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();


// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml"); 
        options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml"); 
    
        options.ViewLocationFormats.Add("/People.Web/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/People.Web/Views/Shared/{0}.cshtml");
    });

builder.Services.AddHttpClient<IRandomUserGeneratorService, RandomUserGeneratorApiService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PeopleContext>(options => options.UseNpgsql(connectionString));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();