using api.Infrastructure.RequestDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Sequences;

public class SequencesGetResponse : BaseGetResponse<SequenceResponse>
{
    public SequencesGetFilterRequest Filter { get; set; }
}
