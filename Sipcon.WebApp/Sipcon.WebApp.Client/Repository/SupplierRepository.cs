namespace Sipcon.WebApp.Client.Repository
{
    using Sipcon.WebApp.Client.Services;
    using Sipcon.WebApp.Client.Models;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;


    public class SupplierRepository(HttpClient http) : ISupplierService
    {
        private readonly HttpClient _http = http;

        



        public async Task<ApiResponse<List<Supplier>>> GetSuppliers(int IdUser)
        {
            ApiResponse<List<Supplier>>? result;

            try
            {
            
                var SupplierList = await _http.GetFromJsonAsync<List<Supplier>>($"api/Contact/GetSuppliers");

                result = (SupplierList is null) ? new ApiResponse<List<Supplier>>()
                {
                    Processed = false,
                    Message = "La respuesta del servidor no contiene datos."
                } : new ApiResponse<List<Supplier>>()
                {
                    Processed = true,
                    Data = [],
                };

                if (result.Processed)
                {
                    result.Data.AddRange(SupplierList ?? []);
                }

            }
            catch (HttpRequestException httpEx)
            {
                result = new ApiResponse<List<Supplier>>()
                {
                    Processed = false,
                    Message = string.Concat("Error al realizar la solicitud HTTP: ", httpEx.Message)
                };

            }
            catch (NotSupportedException notSupportedEx)
            {
                result = new ApiResponse<List<Supplier>>()
                {
                    Processed = false,
                    Message = string.Concat("El formato de la respuesta no es compatible: ", notSupportedEx.Message)
                };

            }
            catch (Exception ex)
            {
                result = new ApiResponse<List<Supplier>>()
                {
                    Processed = false,
                    Message = string.Concat("Ocurrió un error inesperado: ", ex.Message)
                };
            }

            return result;

        }
        public async Task<ApiResponse<Supplier>> GetSupplier(int IdSupplier, int IdUser) 
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
        }

        public async Task<ApiResponse<ActionResult>> CreateSupplier(Supplier Supplier, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");
        }

        public async Task<ApiResponse<ActionResult>> UpdateSupplier(Supplier Supplier, int IdUser)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Method not implement");

        }
      

    }

}
