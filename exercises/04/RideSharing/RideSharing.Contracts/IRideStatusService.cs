using System.ServiceModel;

namespace RideSharing.Contracts;

[ServiceContract]
public interface IRideStatusService
{
    [OperationContract]
    Task<RideStatusEnum> GetRideStatus(Guid requestId);
}
