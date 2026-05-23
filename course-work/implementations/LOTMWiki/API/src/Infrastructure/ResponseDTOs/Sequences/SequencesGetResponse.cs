using api.Infrastructure.RequestDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Sequences;

public class SequencesGetResponse : BaseGetResponse<Sequence>
{
    public SequencesGetFilterRequest Filter { get; set; }
}