using WebApp.Components;
using WebApp.Components.Services;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<UserContext>();

/*
builder.Services.AddScoped<IClientPost, ClientPost>();
builder.Services.AddScoped<IClientComment, ClientComment>();
builder.Services.AddScoped<IClientUserProfile, ClientUserProfile>();
*/
builder.Services.AddHttpClient<IClientPost, ClientPost>();
builder.Services.AddHttpClient<IClientComment, ClientComment>();
builder.Services.AddHttpClient<IClientUserProfile, ClientUserProfile>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsePolicy", builder =>
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsePolicy");

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
