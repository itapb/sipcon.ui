
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sipcon.WebApp.Client.Repository;
using Sipcon.WebApp.Client.Repository.Auth;
using Sipcon.WebApp.Client.Services;
using Sipcon.WebApp.Client.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddScoped<TokenHandler>();
var backEndUrl = builder.Configuration.GetValue<string>("BackEndUrl")!;
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(backEndUrl)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddTransient<ILocalStorageService, LocalStorageRepository>();
builder.Services.AddTransient<ISessionStorageService, SessionStorageRepository>();
builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<IAuthorizeService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());


builder.Services.AddScoped<IModelService, ModelRepository>();
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
builder.Services.AddSingleton<HubEventsService>();
await builder.Build().RunAsync();