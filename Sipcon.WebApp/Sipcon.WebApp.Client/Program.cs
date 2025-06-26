using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sipcon.WebApp.Client.Services;
using Sipcon.WebApp.Client.Repository;
using Sipcon.WebApp.Client.Utils;
using Sipcon.WebApp.Client.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
//builder.Services.AddScoped<TokenHandler>();
var backEndUrl = builder.Configuration.GetValue<string>("BackEndUrl")!;
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(backEndUrl)); //.AddHttpMessageHandler<TokenHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

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

builder.Services.AddTransient<UtilModuleActions>();
builder.Services.AddScoped(typeof(MasterComp<,>));

await builder.Build().RunAsync();