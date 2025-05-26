namespace Sipcon.WebApp.Client.Models
{
    public class PartDetails
    {
        public Part? Part { get; set; }
        public List<RelatedModel>? Models { get; set; }
        public List<Brand>? Brands { get; set; }
        public List<Contact>? Suppliers { get; set; }
        public List<SubFamily>? Subfamilies { get; set; }
        public List<Family>? Families { get; set; }
        public List<PartType>? Types { get; set; }
        public List<Um>? Ums { get; set; }
        public List<Tax>? Taxes { get; set; }
    }
}
