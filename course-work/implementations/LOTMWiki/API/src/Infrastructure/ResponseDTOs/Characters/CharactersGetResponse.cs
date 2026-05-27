using api.Infrastructure.RequestDTOs.Characters;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Characters;

public class CharactersGetResponse : BaseGetResponse<CharacterResponse>
{
    public CharactersGetFilterRequest Filter { get; set; }
}
