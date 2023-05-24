using Azure.Core.Pipeline;
using CVproject.Controllers;
using CVproject.Models;
using CVproject.Models.XML;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Plugins;
using System.Configuration;
using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CvContext>(options => options.UseLazyLoadingProxies().UseSqlServer(
    builder.Configuration.GetConnectionString("CVprojectContext")
    ));

builder.Services.AddIdentity<Person, IdentityRole>()
    .AddEntityFrameworkStores<CvContext>()
    .AddDefaultTokenProviders();

HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback =  (sender, cert, chain, sslPolicyErrors) => true;

HttpClient client = new HttpClient(clientHandler);
client.BaseAddress = new Uri("https://localhost:7211/api/");

builder.Services.AddSingleton<HttpClient>(client);


//THIS IS FOR USE OF _HTTPCONTEXT personcontroller mypage -maybe delete
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Or you can also register as follows

builder.Services.AddHttpContextAccessor();

//Test for dependency injection
builder.Services.AddTransient<MessageRepository>();
//builder.Services.AddTransient<MessageService>();

//test for XML
builder.Services.AddTransient<SerializerForXml>();

// Default Password settings.
// Har ändrat dem så de blivit jättelätta - för test
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Default Password settings.
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 3;
//    options.Password.RequiredUniqueChars = 1;


//});



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
