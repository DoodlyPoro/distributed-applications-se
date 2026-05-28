namespace api.Infrastructure.RequestDTOs.Epochs;

public class EpochsGetFilterRequest
{
    public string Name { get; set; }
    public int Number { get; set; }
    public  int StartYear { get; set; }
    public int EndYear { get; set; }
}