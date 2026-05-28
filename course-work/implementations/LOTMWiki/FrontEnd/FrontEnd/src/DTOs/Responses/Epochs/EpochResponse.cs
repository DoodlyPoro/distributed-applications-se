namespace api.Infrastructure.ResponseDTOs.Epochs;

public class EpochResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}