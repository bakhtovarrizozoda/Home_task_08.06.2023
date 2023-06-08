using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UserDto
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public int JobId { get; set; }
}