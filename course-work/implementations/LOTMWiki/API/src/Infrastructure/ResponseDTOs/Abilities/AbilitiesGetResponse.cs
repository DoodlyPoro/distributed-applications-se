using api.Infrastructure.RequestDTOs.Abilities;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Abilities;

public class AbilitiesGetResponse : BaseGetResponse<AbilityResponse>
{
    public AbilitiesGetFilterRequest Filter { get; set; }
}
