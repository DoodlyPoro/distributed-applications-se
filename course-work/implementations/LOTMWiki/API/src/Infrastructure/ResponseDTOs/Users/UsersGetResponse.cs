using api.Infrastructure.RequestDTOs.Users;
using api.Infrastructure.ResponseDTOs.Shared;
using Common.Entity;

namespace api.Infrastructure.ResponseDTOs.Users;

public class UsersGetResponse : BaseGetResponse<User>
{
    public UsersGetFilterRequest Filter { get; set; }
}