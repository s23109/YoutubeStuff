using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

using YoutubeStuff.Models;
using YoutubeStuff.Services.MusicModule.DownloadUploadService;
using YoutubeStuff.Services.MusicModule.FileControlService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
});

//builder.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Music Module

//IFileControl init in program start
var fileControl = new FileControlService();
builder.Services.AddSingleton<IFileControlService>(fileControl);


builder.Services.AddScoped<IDownloadUploadService, DownloadUploadService>();
// / Music Module

//bootstrap
builder.Services.AddBootstrapBlazor();

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
