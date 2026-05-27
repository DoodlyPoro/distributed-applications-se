namespace api.Infrastructure.ResponseDTOs.Abilities;

public class AbilityResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? SequenceId { get; set; }
}