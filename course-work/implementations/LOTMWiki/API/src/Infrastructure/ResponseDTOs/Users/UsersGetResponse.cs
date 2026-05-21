using api.Infrastructure.RequestDTOs.Users;

namespace api.Infrastructure.ResponseDTOs.Users;

public class UsersGetResponse
{
    public UsersGetFilterRequest Filter { get; set; }
}