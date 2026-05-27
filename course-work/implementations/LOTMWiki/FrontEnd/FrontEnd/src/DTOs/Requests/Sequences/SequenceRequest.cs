namespace api.Infrastructure.RequestDTOs.Sequences;

public class SequenceRequest
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? PathwayId { get; set; }
}