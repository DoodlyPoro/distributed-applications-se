using System.ComponentModel.DataAnnotations.Schema;

namespace RideSharing.Data.Entities
{
    [Table("Rides", Schema = "Rides")]
    public class RideEntity : BaseEntity
    {
        public required string PickupLocation { get; set; }
        public required string DropoffLocation { get; set; }
        public int Status { get; set; }
    }
}