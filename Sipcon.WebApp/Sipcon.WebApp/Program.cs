using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Localization;
using MudBlazor.Services;
using Sipcon.WebApp;
using Sipcon.WebApp.Client.Helper;
using Sipcon.WebApp.Client.Repository;
using Sipcon.WebApp.Client.Repository.Auth;
using Sipcon.WebApp.Client.Services;
using Sipcon.WebApp.Client.Utils;
using Sipcon.WebApp.Components;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// =======================================================
// INICIO: CONFIGURACIÓN DE CULTURA (EN-US / Punto Decimal)
// =======================================================
var cultureInfo = new CultureInfo("en-US");
var supportedCultures = new[] { cultureInfo };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // 1. Configuración del Pipeline HTTP/Model Binding
    options.DefaultRequestCulture = new RequestCulture(cultureInfo);

    // Solo se soportará esta cultura para forzar la consistencia
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // Se eliminan los proveedores para prevenir que la configuración del navegador
    // (ej. español) intente sobrescribir 'en-US'.
    options.RequestCultureProviders.Clear();
});

// 2. CLAVE: Fuerza la cultura de los threads que ejecutan el código Blazor Server y el runtime.
// Esto asegura que el Model Binding de los componentes Blazor use la cultura en-US.
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// =======================================================
// FIN: CONFIGURACIÓN DE CULTURA
// =======================================================

var backEndUrl = "";
var env = builder.Configuration.GetValue<string>("BackEndUrl")!;
backEndUrl = builder.Configuration.GetValue<string>(env)!;

//if (env == "DEV")
//{
//    backEndUrl = builder.Configuration.GetValue<string>("BackEndUrlDEV")!;
//}
//if (env == "QA")
//{
//    backEndUrl = builder.Configuration.GetValue<string>("BackEndUrlQA")!;
//}
//if (env == "PROD")
//{
//    backEndUrl = builder.Configuration.GetValue<string>("BackEndUrl")!;
//}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(backEndUrl)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));
// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazorPdfViewer();

builder.Services.AddScoped<UserSession>();
builder.Services.AddTransient<ISessionStorageService, SessionStorageRepository>();
builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider,AuthenticationProviderJWT>(x=> x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<IAuthorizeService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<HubEventsService>();

builder.Services.AddScoped<IFigoService, FigoRepository>();
builder.Services.AddScoped<IModelService, ModelRepository>();
builder.Services.AddScoped<IModuleService, ModuleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleRepository>();
builder.Services.AddScoped<IVehicleColorService, VehicleColorRepository>();
builder.Services.AddScoped<IInspectionService, InspectionRepository>();
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
builder.Services.AddScoped<IReportDMSService, ReportDMSRepository>();
builder.Services.AddScoped<IReportingService, ReportingRepository>();
builder.Services.AddScoped<IKardexService, KardexRepository>();
builder.Services.AddScoped<IPaymentService, PaymentsRepository>();
builder.Services.AddScoped<IAreaService, AreaRepository>();
builder.Services.AddScoped<IFaseService, FaseRepository>();
builder.Services.AddScoped<IFeatureTypeService, FeatureTypeRepository>();
builder.Services.AddScoped<IFeatureService, FeatureRepository>();
builder.Services.AddScoped<IFeatureOptionService, FeatureOptionRepository>();
builder.Services.AddScoped<IFeatureValueTypeService, FeatureValueTypeRepository>();
builder.Services.AddScoped<IInventoryCountService, InventoryCountRepository>();

builder.Services.AddScoped<IPowerBIService, PowerBIRepository>();
builder.Services.AddScoped<IRateService, RateRepository>();

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

var envPathBase = builder.Configuration.GetValue<string>("PathBase")!;
app.UsePathBase(AppSettingsHelper.GetAppSetting(envPathBase));//app.UsePathBase("/sipconapp/");

string[] urlWith = backEndUrl.Split(':', 2);
if (urlWith[0] == "https")
{
    app.UseHttpsRedirection();
}


// =======================================================
// APLICAR CULTURA: Debe ir antes de app.UseRouting()
// =======================================================
app.UseRequestLocalization();
// =======================================================

app.UseAuthorization();
app.UseRouting();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AllowAnonymous()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Sipcon.WebApp.Client._Imports).Assembly);

app.Run();
