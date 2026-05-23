namespace Common.Entity;

public class Character : BaseEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int? EpochId { get; set; }
    public virtual Epoch? Epoch { get; set; }
    public int? PathwayId { get; set; }
    public virtual Pathway? Pathway { get; set; }
    public int? SequenceId { get; set; }
    public virtual Sequence? Sequence { get; set; }
}