namespace api.Infrastructure.RequestDTOs.Epochs;

public class EpochRequest
{
    public string Name { get; set; }
    public int EpochNumber { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}