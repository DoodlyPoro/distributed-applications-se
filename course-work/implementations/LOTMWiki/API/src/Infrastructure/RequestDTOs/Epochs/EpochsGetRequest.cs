using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.RequestDTOs.Epochs;

public class EpochsGetRequest : BaseGetRequest
{
    public EpochsGetFilterRequest Filter { get; set; }
}