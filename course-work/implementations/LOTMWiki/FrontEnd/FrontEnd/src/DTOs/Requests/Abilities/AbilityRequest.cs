using System.ComponentModel.DataAnnotations;

namespace api.Infrastructure.RequestDTOs.Abilities;

public class AbilityRequest
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(5, ErrorMessage = "Name must be at least 5 characters long.")]
    [MaxLength(25, ErrorMessage = "Name must be no more 25 characters long.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [MinLength(25, ErrorMessage = "Description must be at least 25 characters long.")]
    [MaxLength(250, ErrorMessage = "Description must be no more 250 characters long.")]
    public string Description { get; set; }
    public int? SequenceId { get; set; }
}