using api.Infrastructure.RequestDTOs.Epochs;

namespace api.Infrastructure.ResponseDTOs.Epochs;

public class EpochsGetResponse
{
    public EpochsGetFilterRequest Filter { get; set; }
}