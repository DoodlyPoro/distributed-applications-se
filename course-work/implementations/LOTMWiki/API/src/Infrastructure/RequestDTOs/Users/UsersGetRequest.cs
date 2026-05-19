using api.Infrastructure.RequestDTOs.Shared;

namespace api.Infrastructure.RequestDTOs.Users;

public class UsersGetRequest : BaseGetRequest
{
    public UsersGetFilterRequest Filter { get; set; }
}