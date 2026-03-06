using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using EventEase;
using EventEase.Services;
using Serilog;
using Serilog.Sinks.BrowserConsole;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<EventsService>();
builder.Services.AddScoped<UserSessionTracker>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.BrowserConsole()
    .CreateLogger();

await builder.Build().RunAsync();
