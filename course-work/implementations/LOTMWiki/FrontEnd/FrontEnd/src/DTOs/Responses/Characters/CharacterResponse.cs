namespace api.Infrastructure.ResponseDTOs.Characters;

public class CharacterResponse
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public string Country { get; set; }
    
    public int? EpochId { get; set; }
    public string? EpochName { get; set; }
    
    public int? PathwayId { get; set; }
    public string? PathwayName { get; set; }
    
    public int? SequenceId { get; set; }
    public string? SequenceName { get; set; }
}