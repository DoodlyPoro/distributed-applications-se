using System.Runtime.Serialization;

namespace RideSharing.Contracts.Messaging
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RideSharing.Contracts")]
    public abstract class GuidServiceRequestBase : ServiceRequestBase
    {
        public Guid Id { get; set; }

        public GuidServiceRequestBase(Guid id)
        {
            Id = id;
        }
    }
}
