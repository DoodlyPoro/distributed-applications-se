using RideSharing.Contracts.Messaging.Requests;
using System.ServiceModel;

namespace RideSharing.Contracts;

[ServiceContract]
public interface IRideBookingService
{
    [OperationContract(IsOneWay = true)]
    Task RequestRide(RideRequest request);

    [OperationContract(IsOneWay = true)]
    Task CancelRide(Guid requestId);
}
