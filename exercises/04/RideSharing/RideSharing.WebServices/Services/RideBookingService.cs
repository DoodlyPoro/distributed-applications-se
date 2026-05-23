using RideSharing.ApplicationServices.Interfaces;
using RideSharing.Contracts;
using RideSharing.Contracts.Messaging.Requests;

namespace RideSharing.WebServices.Services
{
    public class RideBookingService : IRideBookingService, IRideStatusService
    {
        private readonly IRideManagementService _rideManagementService;

        public RideBookingService(IRideManagementService rideManagementService)
        {
            _rideManagementService = rideManagementService;
        }

        public async Task CancelRide(Guid requestId)
        {
            await _rideManagementService.CancelAsync(new(requestId));
        }

        public async Task<RideStatusEnum> GetRideStatus(Guid requestId)
        {
            var request = await _rideManagementService.GetStatusAsync(new(requestId));

            return request.RideStatus;
        }

        public async Task RequestRide(RideRequest request)
        {
            await _rideManagementService.RequestAsync(request);
        }
    }
}