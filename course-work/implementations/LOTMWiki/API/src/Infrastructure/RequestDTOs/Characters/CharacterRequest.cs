namespace api.Infrastructure.RequestDTOs.Characters;

public class CharacterRequest
{
    public string  Name { get; set; }
    public string Country { get; set; }
    public int EpochId { get; set; }
    public int PathwayId { get; set; }
    public int SequenceId { get; set; }
}