using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; }
}