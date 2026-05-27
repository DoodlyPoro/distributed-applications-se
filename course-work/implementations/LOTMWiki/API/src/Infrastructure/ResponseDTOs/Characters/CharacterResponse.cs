namespace api.Infrastructure.ResponseDTOs.Characters;

public class CharacterResponse
{
    public string  Name { get; set; }
    public string Country { get; set; }
    public int? EpochId { get; set; }
    public int? PathwayId { get; set; }
    public int? SequenceId { get; set; }
}