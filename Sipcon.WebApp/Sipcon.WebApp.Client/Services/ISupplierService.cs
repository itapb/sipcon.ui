namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    

    public interface ISupplierService
    {

        public Task<ApiResponse<List<Supplier>>> GetSuppliers(int IdUser);
        public Task<ApiResponse<Supplier>> GetSupplier(int IdBrand, int IdUser);
        public Task<ApiResponse<ActionResult>> CreateSupplier(Supplier Supplier, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateSupplier(Supplier Supplier, int IdUser);


    }
}
