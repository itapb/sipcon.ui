namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;

    public class BrandRepository(HttpClient http) : IBrandService
    {
        private readonly HttpClient _http = http;


        public async Task<ApiResponse<List<Brand>>> GetBrands(int IdUser, int RowFrom = 0, string Filter = "")
        {
            ApiResponse<List<Brand>> result;
            try
            {
                var Brands = await _http.GetFromJsonAsync<List<Brand>>($"api/Brand/GetAll");

                result = (Brands is null) ? new ApiResponse<List<Brand>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : new ApiResponse<List<Brand>>(){
                    Processed = true,
                    Data = [],
                };

                if (result.Processed)
                {
                    result.Data.AddRange(Brands ?? []);
                }

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Brand>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Brand>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message),
                 };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Brand>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }
            return result;

        }
        public async Task<Brand> GetBrand(int IdBrand, int IdUser) 
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
        }

        public async Task<bool> CreateBrand(Brand Brand, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
            
        }
        public async Task<bool> UpdateBrand(Brand Brand, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
            


        }
      
    }

}
