using api.Infrastructure.RequestDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Shared;

namespace api.Infrastructure.ResponseDTOs.Sequences;

public class SequencesGetResponse : BaseGetResponse<SequenceResponse>
{
    public SequencesGetFilterRequest Filter { get; set; }
}
