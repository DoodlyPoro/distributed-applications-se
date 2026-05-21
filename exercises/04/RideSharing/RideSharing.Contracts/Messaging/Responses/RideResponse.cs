using System.Runtime.Serialization;

namespace RideSharing.Contracts.Messaging.Responses
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RideSharing.Contracts")]
    public class RideResponse : ServiceResponseBase
    {
        public RideStatusEnum RideStatus { get; set; }
    }
}
