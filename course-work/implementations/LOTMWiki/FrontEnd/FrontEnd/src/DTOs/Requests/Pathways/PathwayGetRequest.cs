using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.RequestDTOs.Pathways;

public class PathwayGetRequest : BaseGetRequest
{
    public PathwayGetFilterRequest Filter { get; set; }
}