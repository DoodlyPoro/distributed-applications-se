namespace api.Infrastructure.RequestDTOs.Abilities;

public class AbilitiesGetFilterRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int? SequenceId { get; set; }
}