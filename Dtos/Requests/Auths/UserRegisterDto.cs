using System.ComponentModel.DataAnnotations;

namespace nheejods.Dtos.Requests.Auths;

public class UserRegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}
