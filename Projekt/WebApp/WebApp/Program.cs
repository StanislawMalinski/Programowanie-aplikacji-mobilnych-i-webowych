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

builder.Services.AddHttpClient<IClientPost, ClientPost>();
builder.Services.AddHttpClient<IClientComment, ClientComment>();
builder.Services.AddHttpClient<IClientUserProfile, ClientUserProfile>();
builder.Services.AddHttpClient<IClientAuth, ClientAuth>();

builder.Services.AddScoped<ILanguageService>(
    provider => new LanguageService(configuration["PathToDictionary"]));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsePolicy", builder =>
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseCors("MyCorsePolicy");

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
