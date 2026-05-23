using RideSharing.Contracts.Messaging.Requests;
using RideSharing.Contracts.Messaging.Responses;

namespace RideSharing.ApplicationServices.Interfaces
{
    public interface IRideManagementService
    {
        Task RequestAsync(RideRequest request);

        Task CancelAsync(RideIdentifierRequest request);

        Task<RideResponse> GetStatusAsync(RideIdentifierRequest request);
    }
}
