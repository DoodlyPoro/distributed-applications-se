using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace api.Infrastructure.RequestDTOs.Sequences;

public class SequenceRequest
{
    [Required(ErrorMessage = "Sequence number is required.")]
    [Range(0, 9, ErrorMessage = "Sequence number must be between 0 and 9.")]
    public int Number { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
    [MaxLength(30, ErrorMessage = "Name must be no more than 30 characters long.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required.")]
    [MinLength(25, ErrorMessage = "Description must be at least 25 characters long.")]
    [MaxLength(250, ErrorMessage = "Description must be no more than 250 characters long.")]
    public string Description { get; set; }
    public int? PathwayId { get; set; }
}