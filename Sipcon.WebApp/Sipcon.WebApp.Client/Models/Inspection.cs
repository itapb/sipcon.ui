
using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Inspection
    {
        public Int32 InspectionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String? Vin { get; set; }
        public String? Plate { get; set; }
        public String? Model { get; set; }
        public String? Area { get; set; }
        public String? User { get; set; }
        public String? Batch { get; set; }
        public Int32? Isclosed { get; set; }
    }

    public class InspectionFase
    {
       public Int32 InspectionId { get; set; }
       public Int32 FaseId { get; set; }
       public String? Fase { get; set; }
       public DateTime? CompletedDate { get; set; }
       public Int32? IsCompleted { get; set; }
       public String? InitDate { get; set; }
       public Int32? AreaId { get; set; }
       public String? Area { get; set; }
       public Int32? UserInitId { get; set; }
       public String? Login { get; set; }
       public Int32? Completed { get; set; }
    }

    public class InspectionDetail
    {
        public int? CreatedBy { get; set; }
        public int? VehicleId { get; set; }
        public int? AreaId { get; set; }

        public int? InitBy { get; set; }
        public int? ClosedBy { get; set; }
        public int? TransporterId { get; set; }
        public int? RecepBy { get; set; }
        public string? Comment { get; set; }
        public int? DealerId { get; set; }

        public String? UserName { get; set; }
        public String? InitByName { get; set; }
        public String? ClosedByName { get; set; }
        public String? TransporterName { get; set; }
        public String? RecepByName { get; set; }

        public String? VehiclePlate { get; set; }
        public String? Model { get; set; }
        public String? Lote { get; set; }
        public String? Vin { get; set; }
        public String? NameArea { get; set; }
        public DateTime? Created { get; set; }

        public DateTime? DInit { get; set; }
        public DateTime? DClose { get; set; }
        public DateTime? DReception { get; set; }

        public Int32? IsCompleted { get; set; }
        public bool? IsDispatch { get; set; }
        public bool? HasFiles { get; set; }
    }

    public class InspectionFeatures
    {
       public Int32 Id { get; set; }
       public Int32? Value { get; set; }
       public String? Observation { get; set; }
       public String? FileUrl { get; set; }
       public Int32? InspectionId { get; set; }
       public Int32? FeatureId { get; set; }
       public String? Feature { get; set; }
       public Int32? FeatureTypeId { get; set; }
       public String? FeatureValueTypeId { get; set; }
       public String? FeatureType { get; set; }
       public String? FaseId { get; set; }
       public String? Fase { get; set; }
       public Int32? AreaId { get; set; }
       public String? Area { get; set; }
       public String? Color { get; set; }
       public String? Model { get; set; }
       public String? Vin { get; set; }
       public String? Plate { get; set; }
       public bool? HasFiles { get; set; }
       public String? OptionSelected { get; set; }
    }

    public class InspectionFiles
    {
        public string? fileName { get; set; }
        public Int32? recordId { get; set; }
        public Int32? moduleId { get; set; }
        public string? moduleName { get; set; }
        public DateTime? dateCreate { get; set; }
        public Int32? Id { get; set; }
        public bool? isActive { get; set; }
    }
}