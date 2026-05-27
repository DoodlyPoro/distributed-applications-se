using System.Collections.Generic;

namespace api.Infrastructure.ResponseDTOs.Shared;

public class BaseGetResponse<TResponse>
{
    public List<TResponse> Items { get; set; }
    public PagerResponse Pager { get; set; }
    public string OrderBy { get; set; }
    public bool SortAsc { get; set; }
}