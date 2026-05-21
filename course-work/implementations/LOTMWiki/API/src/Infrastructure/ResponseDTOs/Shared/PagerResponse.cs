using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.ResponseDTOs.Shared;

public class PagerResponse : PagerRequest
{
    public int Count { get; set; }
}