using RideSharing.Repositories.Interfaces;
using Serilog;

namespace RideSharing.ApplicationServices.Implementations
{
    public class BaseManagementService
    {
        protected readonly ILogger _logger;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseManagementService(ILogger logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
    }
}
