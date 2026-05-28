using System.ComponentModel.DataAnnotations;

namespace api.Infrastructure.RequestDTOs.Epochs;

public class EpochRequest
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(5, ErrorMessage = "Name must be at least 5 characters long.")]
    [MaxLength(30, ErrorMessage = "Name must be no more than 30 characters long.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Epoch number is required.")]
    [Range(0, 10, ErrorMessage = "Epoch number must be between 0 and 10.")]
    public int Number { get; set; }
    
    [Required(ErrorMessage = "Start year is required.")]
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}