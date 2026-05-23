using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.RequestDTOs.Abilities;

public class AbilitiesGetRequest : BaseGetRequest
{
    public AbilitiesGetFilterRequest Filter { get; set; }
}