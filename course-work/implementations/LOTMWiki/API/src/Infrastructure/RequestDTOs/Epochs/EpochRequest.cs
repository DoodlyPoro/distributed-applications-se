namespace api.Infrastructure.RequestDTOs.Epochs;

public class EpochRequest
{
    public string Name { get; set; }
    public int Number { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}