using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Characters;

public class CharactersGetResponse : BaseGetResponse<Character>
{
    public CharactersGetResponse Filter { get; set; }
}