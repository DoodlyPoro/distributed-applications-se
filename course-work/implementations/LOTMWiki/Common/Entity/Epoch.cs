namespace Common.Entity;

public class Epoch : BaseEntity
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}