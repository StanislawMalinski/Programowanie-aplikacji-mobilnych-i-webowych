using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Configuration;
using Shared.Services;
using Shared.Services.ProductService;
using WebAssemblyApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    Path = appSettingsSection.BaseProductEndpoint.Base_url,
};
//Microsoft.Extensions.Http
builder.Services.AddHttpClient<IProductService, ProductService>(client => client.BaseAddress = uriBuilder.Uri);
//builder.Services.Configure<AppSettings>(appSettings);
builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));
builder.Services.AddSingleton<IAddFilmService, AddFilmService>();
builder.Services.AddSingleton<IFilmClientService, FilmClientService>();
builder.Services.AddSingleton<IFilmSearchService, FilmSearchService>();

await builder.Build().RunAsync();
