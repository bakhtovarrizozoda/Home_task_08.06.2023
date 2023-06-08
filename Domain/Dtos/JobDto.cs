using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class JobDto
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public DateTime ClosingData { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Text { get; set; }
}