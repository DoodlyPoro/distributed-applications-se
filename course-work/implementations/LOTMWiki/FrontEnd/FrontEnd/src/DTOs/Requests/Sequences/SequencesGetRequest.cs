using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.RequestDTOs.Sequences;

public class SequenceGetRequest : BaseGetRequest
{
    public SequencesGetFilterRequest Filter { get; set; }
}