using api.Infrastructure.RequestDTOs.Pathways;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Pathways;

public class PathwaysGetResponse : BaseGetResponse<PathwayResponse>
{
    public PathwayGetFilterRequest Filter { get; set; }
}
