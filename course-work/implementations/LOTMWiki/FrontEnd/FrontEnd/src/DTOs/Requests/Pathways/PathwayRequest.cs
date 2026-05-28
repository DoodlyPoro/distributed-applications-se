using System.ComponentModel.DataAnnotations;

namespace api.Infrastructure.RequestDTOs.Pathways;

public class PathwayRequest
{
    [Required(ErrorMessage = "Pathway name is required.")]
    [MinLength(4, ErrorMessage = "Pathway name must be at least 4 characters long.")]
    [MaxLength(25, ErrorMessage = "Pathway name must be no more than 25 characters long.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Pathway description is required.")]
    [MinLength(25, ErrorMessage = "Pathway description must be at least 25 characters long.")]
    [MaxLength(250, ErrorMessage = "Pathway description must be no more than 250 characters long.")]
    public string Description { get; set; }
}