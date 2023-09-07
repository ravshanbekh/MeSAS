using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Users;

public class UserCreationDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [EmailAddress]
    public string Phone { get; set; }
    public string Address { get; set; }
}
