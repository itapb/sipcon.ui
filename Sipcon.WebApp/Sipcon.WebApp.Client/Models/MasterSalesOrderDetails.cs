namespace Sipcon.WebApp.Client.Models
{
    public class MasterSalesOrderDetails
    {
        public SaleOrder? SaleOrder { get; set; }
        public List<SaleOrderDetails>? Details { get; set; }
    }
}
