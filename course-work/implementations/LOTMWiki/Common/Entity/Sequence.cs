namespace Common.Entity;

public class Sequence : BaseEntity
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? PathwayId { get; set; }
    public virtual Pathway?  Pathway { get; set; }
}