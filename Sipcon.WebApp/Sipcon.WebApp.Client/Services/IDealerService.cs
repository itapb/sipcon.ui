namespace Sipcon.WebApp.Client.Services
{
    using Sipcon.WebApp.Client.Models;
    

    public interface IDealerService
    {

        public Task<ApiResponse<List<Dealer>>> GetDealers(int IdUser, int IdSupplier);
        public Task<ApiResponse<Dealer>> GetDealer(int IdBrand, int IdUser);
        public Task<ApiResponse<ActionResult>> CreateDealer(Dealer Dealer, int IdUser);
        public Task<ApiResponse<ActionResult>> UpdateDealer(Dealer Dealer, int IdUser);


    }
}
