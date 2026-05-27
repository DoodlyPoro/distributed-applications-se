namespace api.Infrastructure.ResponseDTOs.Epochs;

public class EpochResponse
{
    public string Name { get; set; }
    public int Number { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}