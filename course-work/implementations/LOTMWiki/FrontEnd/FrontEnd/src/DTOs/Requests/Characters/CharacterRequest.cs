using System.ComponentModel.DataAnnotations;

namespace api.Infrastructure.RequestDTOs.Characters;

public class CharacterRequest
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
    [MaxLength(25, ErrorMessage = "Name must be no more than 25 characters long.")]
    public string  Name { get; set; }
    
    [Required(ErrorMessage = "Country name is required.")]
    [MinLength(4, ErrorMessage = "Country name must be at least 4 characters long.")]
    [MaxLength(25, ErrorMessage = "Country name must be no more than 25 characters long.")]
    public string Country { get; set; }
    public int? EpochId { get; set; }
    public int? PathwayId { get; set; }
    public int? SequenceId { get; set; }
}