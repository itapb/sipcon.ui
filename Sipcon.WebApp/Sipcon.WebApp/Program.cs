using MudBlazor.Services;
using Sipcon.WebApp.Components;


var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.Configuration["BackEndUrl"]!)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UsePathBase("/sipconapp/");
//app.UseHttpsRedirection();
app.UseRouting();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
     .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Sipcon.WebApp.Client._Imports).Assembly);

app.Run();
