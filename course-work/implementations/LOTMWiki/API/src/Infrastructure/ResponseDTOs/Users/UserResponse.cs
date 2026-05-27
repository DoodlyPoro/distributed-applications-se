namespace api.Infrastructure.ResponseDTOs.Users;

public class UserResponse
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
}