using RideSharing.ApplicationServices.Interfaces;
using RideSharing.Contracts;
using RideSharing.Contracts.Messaging.Requests;
using RideSharing.Contracts.Messaging.Responses;
using RideSharing.Data.Entities;
using RideSharing.Repositories.Interfaces;
using Serilog;

namespace RideSharing.ApplicationServices.Implementations
{
    public class RideManagementService : BaseManagementService, IRideManagementService
    {
        public RideManagementService(ILogger logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }

        public async Task RequestAsync(RideRequest request)
        {
            _logger.Information(
                "Ride received - RequestId: {RequestId}, Pickup: {Pickup}, Dropoff: {Dropoff}, Status: {Status}",
                request.RequestId, request.PickupLocation, request.DropoffLocation, request.Status);

            try
            {
                var entity = ToEntity(request);
                await _unitOfWork.Rides.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                _logger.Information("Ride {RequestId} persisted to database.", request.RequestId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ride request with request id {RequestId} is not save!", request.RequestId);
                throw;
            }
        }

        public async Task CancelAsync(RideIdentifierRequest request)
        {
            var entity = await _unitOfWork.Rides.GetByIdAsync(request.Id);
            if (entity is null)
            {
                _logger.Warning("Cancel failed - Ride {Id} not found.", request.Id);
                return;
            }

            try
            {
                if (entity.Status is (int)RideStatusEnum.Completed or (int)RideStatusEnum.Assigned)
                {
                    _logger.Warning(
                        "Cancel failed - Ride {Id} is already {Status}.",
                        request.Id, entity.Status);
                    return;
                }

                entity.Status = (int)RideStatusEnum.Cancelled;
                _unitOfWork.Rides.Update(entity);
                await _unitOfWork.SaveChangesAsync();

                _logger.Information("Ride {Id} has been cancelled.", request.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ride request with request id {Id} is not save!", request.Id);
                throw;
            }
        }

        public async Task<RideResponse> GetStatusAsync(RideIdentifierRequest request)
        {
            RideResponse response = new();
            var entity = await _unitOfWork.Rides.GetByIdAsync(request.Id);
            if (entity is null)
            {
                _logger.Warning("Ride {Id} not found.", request.Id);
                response.RideStatus = RideStatusEnum.Created;
                return response;
            }

            _logger.Information("Ride {Id} status: {Status}", request.Id, entity.Status);
            response.RideStatus = (RideStatusEnum)entity.Status;
            return response;
        }

        // --- Mapping helpers ---

        private static RideEntity ToEntity(RideRequest contract) => new()
        {
            Id = contract.RequestId,
            PickupLocation = contract.PickupLocation,
            DropoffLocation = contract.DropoffLocation,
            Status = (int)contract.Status,
        };
    }
}
