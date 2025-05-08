using MudBlazor.Services;
using Sipcon.WebApp.Components;
using Sipcon.WebApp.Client.Services;
using Sipcon.WebApp.Client.Repository;
using Sipcon.WebApp.Client.Utils;


var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.Configuration["BackEndUrl"]!)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

builder.Services.AddScoped<IModelService, ModelRepository>();
builder.Services.AddScoped<IModuleService, ModuleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleRepository>();
builder.Services.AddScoped<IVehicleColorService, VehicleColorRepository>();
builder.Services.AddScoped<IBrandService, BrandRepository>();
builder.Services.AddScoped<IPolicyTypeService, PolicyTypeRepository>();
builder.Services.AddScoped<ISupplierService, SupplierRepository>();
builder.Services.AddScoped<IDealerService, DealerRepository>();

builder.Services.AddTransient<UtilModuleActions>();

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
