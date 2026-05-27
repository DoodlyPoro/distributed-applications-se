using api.Infrastructure.RequestDTOs.Users;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Users;

public class UsersGetResponse : BaseGetResponse<UserResponse>
{
    public UsersGetFilterRequest Filter { get; set; }
}
