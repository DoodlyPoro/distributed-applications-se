using System.Runtime.Serialization;

namespace RideSharing.Contracts.Messaging
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RideSharing.Contracts")]
    public abstract class ServiceResponseBase
    {
        public BusnessStatusCodeEnum StatusCode { get; set; }

        public ServiceResponseBase()
        {
            StatusCode = BusnessStatusCodeEnum.None;
        }

        public ServiceResponseBase(BusnessStatusCodeEnum statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
