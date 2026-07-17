using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sipcon.WebApp.Client.Helper;
using Sipcon.WebApp.Client.Repository;
using Sipcon.WebApp.Client.Repository.Auth;
using Sipcon.WebApp.Client.Services;
using Sipcon.WebApp.Client.Utils;
using System.Globalization;


//var fix1 = Enumerable.SequenceEqual(new List<object>(), new List<object>());
//var fix2 = Enumerable.SequenceEqual(new List<string>(), new List<string>());
//var fix3 = Enumerable.SequenceEqual(new List<int>(), new List<int>());
//var fix4 = Enumerable.SequenceEqual(new Dictionary<string, object>().Keys, new Dictionary<string, object>().Keys);
//var fix5 = Enumerable.SequenceEqual(new Dictionary<string, object>().Values, new Dictionary<string, object>().Values);

//Console.WriteLine($"Fixes loaded: {fix1 || fix2 || fix3}");


var builder = WebAssemblyHostBuilder.CreateDefault(args);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");


//builder.Services.AddScoped<TokenHandler>();
//var backEndUrl = builder.Configuration.GetValue<string>("BackEndUrl")!;
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

builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(backEndUrl)); 
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddBlazorPdfViewer();

builder.Services.AddTransient<ISessionStorageService, SessionStorageRepository>();
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<IAuthorizeService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());


builder.Services.AddScoped<IDemandService, DemandRepository>();

builder.Services.AddScoped<IFigoService, FigoRepository>();
builder.Services.AddScoped<IModelService, ModelRepository>();
builder.Services.AddScoped<IModuleService, ModuleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleRepository>();
builder.Services.AddScoped<IVehicleColorService, VehicleColorRepository>();
builder.Services.AddScoped<IBrandService, BrandRepository>();
builder.Services.AddScoped<IPolicyTypeService, PolicyTypeRepository>();
builder.Services.AddScoped<IInspectionService, InspectionRepository>();
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
builder.Services.AddScoped<IRateService, RateRepository>();
builder.Services.AddScoped<IAreaService, AreaRepository>(); 
builder.Services.AddScoped<IFaseService, FaseRepository>();
builder.Services.AddScoped<IFeatureTypeService, FeatureTypeRepository>();
builder.Services.AddScoped<IFeatureService, FeatureRepository>();
builder.Services.AddScoped<IPaymentService, PaymentsRepository>();
builder.Services.AddScoped<IPowerBIService, PowerBIRepository>();

builder.Services.AddScoped<IFeatureOptionService, FeatureOptionRepository>();
builder.Services.AddScoped<IFeatureValueTypeService, FeatureValueTypeRepository>();

builder.Services.AddTransient<UtilModuleActions>();
builder.Services.AddScoped(typeof(MasterComp<,>));
builder.Services.AddSingleton<HubEventsService>();

await builder.Build().RunAsync();