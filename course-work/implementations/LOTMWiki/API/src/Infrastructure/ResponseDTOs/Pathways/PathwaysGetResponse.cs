using api.Infrastructure.RequestDTOs.Pathways;

namespace api.Infrastructure.ResponseDTOs.Pathways;

public class PathwaysGetResponse
{
    public PathwayGetFilterRequest Filter { get; set; }
}