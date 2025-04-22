using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
//builder.Services.AddScoped<TokenHandler>();
var backEndUrl = builder.Configuration.GetValue<string>("BackEndUrl")!;
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(backEndUrl)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

await builder.Build().RunAsync();