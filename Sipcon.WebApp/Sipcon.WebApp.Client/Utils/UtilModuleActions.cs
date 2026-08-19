
using MudBlazor;
using Sipcon.WebApp.Client.Models;
using Sipcon.WebApp.Client.Services;
using System.Diagnostics;


namespace Sipcon.WebApp.Client.Utils
{
    public class UtilModuleActions(
        IModuleService ModuleService,
        IVehicleColorService VehicleColorService,
        IModelService ModelService,
        ISupplierService SupplierService,
        IDealerService DealerService,
        IBrandService BrandService,
        IPolicyTypeService PolicyTypeService,
        IPayMethodService PayMethodService,
        ILicenseService LicenseService,
        IFailReportService FailReportService,
        IAssistenceService AssistenceService,
        IReportDMSService ReportDMSService,
        IReportingService ReportingService,
        IAreaService AreaService,          
        IFaseService FaseService,         
        IFeatureTypeService FeatureTypeService ,  
        IPaymentService PaymentService,  
        IFeatureOptionService FeatureOptionService,
        IFeatureValueTypeService FeatureValueTypeService,
        IInventoryCountService InventoryCountService
        )
    {

        //private readonly IModuleService ServiceModule = Service;
        //private readonly IVehicleColorService ServiceVehicleColor = VehicleColorService;     

        public async Task<List<ModuleAction>> GetModuleActions(int IdUser, string ModuleName)
        {
            List<ModuleAction> _itemsModules = new([]);
            List<Module> _Modules = [];

            var moduleResponse = await ModuleService.GetModules(IdUser, ModuleName);
            if (moduleResponse.Processed)
            {
                _Modules = moduleResponse.Data ?? new List<Module>();
                foreach (var module in _Modules.ToList())
                {
                    switch (module.ActionName)
                    {
                        case "IMPORT":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.Upload, module.Id, module.ActionName, Color.Info));
                            break;
                        case "EXPORT":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.Download, module.Id, module.ActionName, Color.Info));
                            break;
                        case "ACTIVATE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.VerifiedUser, module.Id, module.ActionName, Color.Info));
                            break;
                        case "DEACTIVATE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.Dangerous, module.Id, module.ActionName, Color.Info));
                            break;
                        case "ASSIGN":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.Label, module.Id, module.ActionName, Color.Info));
                            break;
                        case "UNASSIGN":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Outlined.LabelOff, module.Id, module.ActionName, Color.Info));
                            break;
                        case "AVAILABLE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.DirectionsCarFilled, module.Id, module.ActionName, Color.Info));
                            break;
                        case "UNAVAILABLE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.CarCrash, module.Id, module.ActionName, Color.Info));
                            break;
                        case "LOCK":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.Lock, module.Id, module.ActionName, Color.Info));
                            break;
                        case "UNLOCK":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.LockOpen, module.Id, module.ActionName, Color.Info));
                            break;
                        case "GENERATE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Outlined.Task, module.Id, module.ActionName, Color.Info));
                            break;
                        case "TOAPPROVE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Outlined.ThumbUp, module.Id, module.ActionName, Color.Info));
                            break;
                        case "APPROVE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.ThumbUp, module.Id, module.ActionName, Color.Info));
                            break;
                        case "DECLINE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Outlined.ThumbDown, module.Id, module.ActionName, Color.Info));
                            break;
                        case "TOVALIDATE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Outlined.ThumbUp, module.Id, module.ActionName, Color.Info));
                            break;
                        case "VALIDATE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.DoneOutline, module.Id, module.ActionName, Color.Info));
                            break;
                        case "NOTVALIDATE":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.ThumbDown, module.Id, module.ActionName, Color.Info));
                            break;
                        case "PROCESS":
                            _itemsModules.Add(new ModuleAction(module.ActionDisplay, "#", false, Icons.Material.Filled.PlayLesson, module.Id, module.ActionName, Color.Info));
                            break;
                        default:
                            Console.WriteLine($"Acción no reconocida: {module.ActionName}");
                            break;
                    }

                }
            }
            return _itemsModules;

        }

        // ── Inspección ──────────────────────────────────────────────────────── 
        private List<SelectOption>? _cachedFeatureTypeOptions = null;
        private List<SelectOption>? _cachedModelOptions = null;
        private List<SelectOption>? _cachedOptionValueOptions = null;
        private string _cacheKey = string.Empty;

        private string BuildKey(int supplierId, int dealerId) => $"{supplierId}_{dealerId}";
        /// <summary>Áreas activas — usado en FaseDialog, FeatureTypeDialog, FeatureDialog.</summary>
        public async Task<List<SelectOption>> GetAreaOption(int IdUser, int IdSupplier, int IdDealer)
        {
            List<SelectOption> _itemsSelect = new([]);
            var response = await AreaService.GetAreas(IdUser, IdSupplier, IdDealer, active: true);
            if (response.Processed)
                foreach (var item in response.Data ?? new List<Area>())
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name ?? string.Empty));
            return _itemsSelect;
        }

        /// <summary>Fases activas — usado en FeatureTypeDialog.</summary>
        public async Task<List<SelectOption>> GetFaseOption(int IdUser, int IdSupplier, int IdDealer)
        {
            List<SelectOption> _itemsSelect = new([]);
            var response = await FaseService.GetFases(IdUser, IdSupplier, IdDealer, active: true);
            if (response.Processed)
                foreach (var item in response.Data ?? new List<Fase>())
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name ?? string.Empty)
                    {
                        ParentId = item.AreaId,
                        ParentText = item.AreaName ?? string.Empty
                    });
            return _itemsSelect;
        }
        /// <summary>Tipos de característica activos filtrados por Fase — usado en FeatureDialog.</summary> 
        public async Task<List<SelectOption>> GetFeatureTypeOption(int IdUser, int IdSupplier, int IdDealer)
        {
            var key = BuildKey(IdSupplier, IdDealer);
            if (_cachedFeatureTypeOptions is not null && _cacheKey == key)
                return _cachedFeatureTypeOptions;

            List<SelectOption> _itemsSelect = new([]);
            var response = await FeatureTypeService.GetFeatureTypes(IdUser, IdSupplier, IdDealer, active: true);
            if (response.Processed)
                foreach (var item in response.Data ?? new List<FeatureType>())
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name ?? string.Empty)
                    {
                        ParentId = item.FaseId,
                        ParentText = item.FaseName ?? string.Empty,
                        ExtraText = item.AreaName ?? string.Empty
                    });
            _cachedFeatureTypeOptions = _itemsSelect;
            _cacheKey = key;
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetOption(int userId, int featureId)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await FeatureOptionService.GetFeatureOptions(userId, featureId);
            if (moduleResponse.Processed)
            {
                List<FeatureOption> _List = moduleResponse.Data ?? new List<FeatureOption>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetOptionValue(int userId)
        {
            if (_cachedOptionValueOptions is not null)
                return _cachedOptionValueOptions;

            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await FeatureValueTypeService.GetFeatureValueTypes( userId);
            if (moduleResponse.Processed)
            {
                List<FeatureValueType> _List = moduleResponse.Data ?? new List<FeatureValueType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            _cachedOptionValueOptions = _itemsSelect;
            return _itemsSelect;

        }
        // ── Vehículos ─────────────────────────────────────────────────────────
        public async Task<List<SelectOption>> GetColorOption(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);
            

            var moduleResponse = await VehicleColorService.GetVehicleColors(IdUser);
            if (moduleResponse.Processed)
            {
                List<VehicleColor> _List = moduleResponse.Data ?? new List<VehicleColor>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }


        public async Task<List<SelectOption>> GetModelOption(int IdSupplier, int IdUser, int IdBrand = 0)
        {
            List<SelectOption> _itemsSelect = new([]);
            

            var moduleResponse = await ModelService.GetModels(IdSupplier, IdUser, 0);
            if (moduleResponse.Processed)
            {
                List<Model> _List = moduleResponse.Data ?? new List<Model>();

                if (IdBrand != 0)
                {
                    _List = _List.Where(x => x.BrandId == IdBrand).ToList();
                }

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetReportType(int IdSupplier)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await ReportDMSService.GetImportType(IdSupplier);
            if (moduleResponse.Processed)
            {
                List<ReportingType> _List = moduleResponse.Data ?? new List<ReportingType>();
                
                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetReportingType(int idUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await ReportingService.GetReportingType(idUser, 0);
            if (moduleResponse.Processed)
            {
                List<ReportingType> _List = moduleResponse.Data ?? new List<ReportingType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }


        public async Task<List<ReportingTypeFigo>> GetReportingTypeFigo(int idUser)
        {
            var moduleResponse = await ReportingService.GetReportingTypeFigo(idUser, 0);

            return moduleResponse.Processed
                ? moduleResponse.Data ?? new List<ReportingTypeFigo>()
                : new List<ReportingTypeFigo>();
        }

        public async Task<List<SelectOption>> GetSupplierOption(int IdUser, int IdBrand = 0)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await SupplierService.GetSuppliers(IdUser);
            if (moduleResponse.Processed)
            {
                List<Supplier> _List = moduleResponse.Data ?? new List<Supplier>();

                if (IdBrand != 0)
                {
                    _List = _List.Where(x => x.BrandId == IdBrand).ToList();
                }

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.FirstName));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<Supplier>> GetSupplierList(int IdUser)
        {
            List<Supplier> _List = new([]);

            var moduleResponse = await SupplierService.GetSuppliers(IdUser);
            if (moduleResponse.Processed)
            {
                _List = moduleResponse.Data ?? new List<Supplier>();
            }
            return _List;

        }

        public async Task<List<SelectOption>> GetDealerOption(int IdUser, int IdSupplier)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await DealerService.GetDealers(IdUser, IdSupplier);
            if (moduleResponse.Processed)
            {
                List<Dealer> _List = moduleResponse.Data ?? new List<Dealer>();


                foreach (var item in _List.ToList())
                {
                    
                    _itemsSelect.Add(new SelectOption(item.Id, item.FirstName));
                    
                    
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetBrandOption(int IdSupplier)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await BrandService.GetBrands(IdSupplier);
            if (moduleResponse.Processed)
            {
                List<Brand> _List = moduleResponse.Data ?? new List<Brand>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }


        public async Task<List<SelectOption>> GetLicenseTypeOption(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var response = await LicenseService.GetLicenseType(IdUser);
            if (response.Processed)
            {
                List<LicenseType> _List = response.Data ?? new List<LicenseType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetPolicyTypeOption(int IdSupplier, int IdUser, int? IdBrand = null)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PolicyTypeService.GetPolicyTypes(IdSupplier, IdUser, 0,"", IdBrand);
            if (moduleResponse.Processed)
            {
                List<PolicyType> _List = moduleResponse.Data ?? new List<PolicyType>();

                if (IdBrand != 0)
                {
                    _List = _List.Where(x => x.BrandId == IdBrand).ToList();
                }
                
                foreach (var item in _List.ToList())
                {
                    if (item.IsActive)
                    {
                        _itemsSelect.Add(new SelectOption(item.Id, item.Description));
                    }
                }
            }
            return _itemsSelect;

        }


        public async Task<List<SelectOption>> GetPayMethodOption(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PayMethodService.GetPayMethods(IdUser);
            if (moduleResponse.Processed)
            {
                List<PayMethod> _List = moduleResponse.Data ?? new List<PayMethod>();


                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetFailReportType(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await FailReportService.GetFailReportTypes(IdUser);
            if (moduleResponse.Processed)
            {
                List<FailReportType> _List = moduleResponse.Data ?? new List<FailReportType>();


                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }


        public async Task<List<SelectOption>> GetInventoryCountTypeOption(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await InventoryCountService.GetInventoryCountTypes(IdUser);
            if (moduleResponse.Processed)
            {
                List<InventoryCountType> _List = moduleResponse.Data ?? new List<InventoryCountType>();


                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }



        public async Task<List<SelectOption>> GetPossibleFaultOption(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var response = await AssistenceService.GetPossibleFault(IdUser);
            if (response.Processed)
            {
                List<PossibleFault> _List = response.Data ?? new List<PossibleFault>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetAssistanceType(int IdUser)
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await AssistenceService.GetAssistanceType(IdUser);
            if (moduleResponse.Processed)
            {
                List<AssistanceType> _List = moduleResponse.Data ?? new List<AssistanceType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;

        }

        public async Task<List<SelectOption>> GetCurrencySelectOption()
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PaymentService.GetCurrencyType();
            if (moduleResponse.Processed)
            {
                List<CurrencyType> _List = moduleResponse.Data ?? new List<CurrencyType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetPaymentSelectOption()
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PaymentService.GetPaymentType();
            if (moduleResponse.Processed)
            {
                List<PaymentType> _List = moduleResponse.Data ?? new List<PaymentType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Name));
                }
            }
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetDocumentTypeSelectOption()
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PaymentService.GetDocumentType();
            if (moduleResponse.Processed)
            {
                List<DocumentType> _List = moduleResponse.Data ?? new List<DocumentType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Code, item.Name));
                }
            }
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetDocumentStatusSelectOption()
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PaymentService.GetDocumentStatus();
            if (moduleResponse.Processed)
            {
                List<DocumentStatus> _List = moduleResponse.Data ?? new List<DocumentStatus>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Display));
                }
            }
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetDocumentConceptSelectOption()
        {
            List<SelectOption> _itemsSelect = new([]);


            var moduleResponse = await PaymentService.GetDocumentConceptsType();
            if (moduleResponse.Processed)
            {
                List<ConceptsType> _List = moduleResponse.Data ?? new List<ConceptsType>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Code, item.Name));
                }
            }
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetBankAccountSelectOption(int Idsupplier, int? IdCurrency = null)
        {
            List<SelectOption> _itemsSelect = new([]);

            var moduleResponse = await PaymentService.GetBankAccounts(Idsupplier, IdCurrency);
            if (moduleResponse.Processed)
            {
                List<BankAccountsType> _List = moduleResponse.Data ?? new List<BankAccountsType>();

                foreach (var item in _List.OrderBy(x => x.Code).ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Code + "-" + item.Account));
                }
            }
            return _itemsSelect;
        }

        public async Task<List<SelectOption>> GetBankOriginSelectOption()
        {
            List<SelectOption> _itemsSelect = new([]);

            var moduleResponse = await PaymentService.GetBankOrigin();
            if (moduleResponse.Processed)
            {
                List<BankAccountsType> _List = moduleResponse.Data ?? new List<BankAccountsType>();

                foreach (var item in _List.OrderBy(x => x.Code).ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.Id, item.Code + "-" + item.Name));
                }
            }
            return _itemsSelect;
        }
        public async Task<List<SelectOption>> GetStatusByModule(int IdUser, string ModuleName)
        {
            List<SelectOption> _itemsSelect = new([]);

            var moduleResponse = await ModuleService.GetStatusByModule(IdUser, ModuleName);
            if (moduleResponse.Processed)
            {
                List<ActionModule> _List = moduleResponse.Data ?? new List<ActionModule>();

                foreach (var item in _List.ToList())
                {
                    _itemsSelect.Add(new SelectOption(item.ActionId, item.ActionName));
                }
            }
            return _itemsSelect;

        }

    }
}
