namespace Common.Entity;

public class Ability : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int SequenceId { get; set; }
    public virtual Sequence Sequence { get; set; }
}