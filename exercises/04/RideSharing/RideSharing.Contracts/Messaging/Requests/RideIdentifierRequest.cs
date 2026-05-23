using System.Runtime.Serialization;

namespace RideSharing.Contracts.Messaging.Requests
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RideSharing.Contracts")]
    public class RideIdentifierRequest : GuidServiceRequestBase
    {
        public RideIdentifierRequest(Guid id) : base(id)
        {
        }
    }
}
