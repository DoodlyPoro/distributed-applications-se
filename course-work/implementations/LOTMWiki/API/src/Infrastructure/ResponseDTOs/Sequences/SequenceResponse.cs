namespace api.Infrastructure.ResponseDTOs.Sequences;

public class SequenceResponse
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? PathwayId { get; set; }
    public string? PathwayName { get; set; }
}