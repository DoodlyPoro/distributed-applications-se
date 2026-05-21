using System.Runtime.Serialization;

namespace RideSharing.Contracts.Messaging.Requests
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RideSharing.Contracts")]
    public class RideRequest : ServiceRequestBase
    {
        [DataMember(Order = 1)]
        public Guid RequestId { get; set; }

        [DataMember(Order = 2)]
        public string? PickupLocation { get; set; }

        [DataMember(Order = 3)]
        public string? DropoffLocation { get; set; }

        [DataMember(Order = 4)]
        public RideStatusEnum Status { get; set; }
    }
}