using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Sipcon.WebApp;
using Sipcon.WebApp.Client.Repository;
using Sipcon.WebApp.Client.Repository.Auth;
using Sipcon.WebApp.Client.Services;
using Sipcon.WebApp.Client.Utils;
using Sipcon.WebApp.Components;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.Configuration["BackEndUrl"]!)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));
// Add MudBlazor services
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddTransient<ILocalStorageService, LocalStorageRepository>();
builder.Services.AddTransient<ISessionStorageService, SessionStorageRepository>();
builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider,AuthenticationProviderJWT>(x=> x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<IAuthorizeService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<HubEventsService>();


builder.Services.AddScoped<IModelService, ModelRepository>();
builder.Services.AddScoped<IModuleService, ModuleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleRepository>();
builder.Services.AddScoped<IVehicleColorService, VehicleColorRepository>();
builder.Services.AddScoped<IBrandService, BrandRepository>();
builder.Services.AddScoped<IPolicyTypeService, PolicyTypeRepository>();
builder.Services.AddScoped<ISupplierService, SupplierRepository>();
builder.Services.AddScoped<IDealerService, DealerRepository>();
builder.Services.AddScoped<IPolicyService, PolicyRepository>();
builder.Services.AddScoped<IPayMethodService, PayMethodRepository>();
builder.Services.AddScoped<IContactService, ContactRepository>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceRepository>();
builder.Services.AddScoped<IAssistenceService, AssistenceRepository>();
builder.Services.AddScoped<IAttachmentService, AttachmentRepository>();
builder.Services.AddScoped<ICommentService, CommentRepository>();
builder.Services.AddScoped<ILaborTimeService, LaborTimeRepository>();
builder.Services.AddScoped<ILicenseService, LicenseRepository>();
builder.Services.AddScoped<IFailReportService, FailReportRepository>();
builder.Services.AddScoped<ISecurityService, SecurityRepository>();


builder.Services.AddTransient<UtilModuleActions>();
builder.Services.AddScoped(typeof(MasterComp<,>));

var app = builder.Build();
AppSettingsHelper.AppSettingsConfigure(app.Services.GetRequiredService<IConfiguration>());
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
app.UsePathBase(AppSettingsHelper.GetAppSetting("pathBase"));//app.UsePathBase("/sipconapp/");
//app.UseHttpsRedirection();
app.UseRouting();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Sipcon.WebApp.Client._Imports).Assembly);

app.Run();
