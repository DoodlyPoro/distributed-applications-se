using api.Infrastructure.RequestDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Epochs;

public class EpochsGetResponse : BaseGetResponse<EpochResponse>
{
    public EpochsGetFilterRequest Filter { get; set; }
}
