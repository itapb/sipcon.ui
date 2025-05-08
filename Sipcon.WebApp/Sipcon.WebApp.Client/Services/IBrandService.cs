namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    

    public interface IBrandService
    {

        public Task<ApiResponse<List<Brand>>> GetBrands(int IdUser, int RowFrom = 0, string Filter = "");
        public Task<Brand> GetBrand(int IdBrand, int IdUser);
        public Task<bool> CreateBrand(Brand Brand, int IdUser);
        public Task<bool> UpdateBrand(Brand Brand, int IdUser);


    }
}
