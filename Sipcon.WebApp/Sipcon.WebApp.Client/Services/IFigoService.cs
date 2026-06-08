namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;

    public interface IFigoService
    {
        Task<ApiResponse<List<FIGO_Reporte_RelacionCxC>>> GetRelacionCxC(string _activeCurrency, string _searchString);
        Task<ApiResponse<List<byte>>> ExportRelacionCxCExcel(string _activeCurrency, string _searchString);
        Task<ApiResponse<List<byte>>> ExportRelacionCxCPDF(string _activeCurrency, string _searchString);
    }
}
