using api.Infrastructure.RequestDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Epochs;

public class EpochsGetResponse : BaseGetResponse<Epoch>
{
    public EpochsGetFilterRequest Filter { get; set; }
}