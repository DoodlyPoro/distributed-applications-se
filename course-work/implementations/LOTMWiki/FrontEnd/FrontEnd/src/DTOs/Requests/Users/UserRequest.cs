using System.ComponentModel.DataAnnotations;

namespace api.Infrastructure.RequestDTOs.Users;

public class UserRequest
{
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(5, ErrorMessage = "Username must be at least 5 characters long.")]
    [MaxLength(20, ErrorMessage = "Username must be no more than 20 characters long.")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(5, ErrorMessage = "Password must be at least 5 characters long.")]
    [MaxLength(20, ErrorMessage = "Password must be no more than 20 characters long.")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "First name is required.")]
    [MaxLength(25, ErrorMessage = "First name must be no more than 25 characters long.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(25, ErrorMessage = "Last name must be no more than 25 characters long.")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Age is required.")]
    [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
    public int Age { get; set; }
}