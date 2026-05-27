using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.RequestDTOs.Characters;

public class CharactersGetRequest : BaseGetRequest
{
    public CharactersGetFilterRequest Filter { get; set; }
}