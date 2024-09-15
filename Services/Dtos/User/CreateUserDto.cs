using System;

namespace nheejods.Services.Dtos.User;

public class CreateUserDto
{
    public required string Email { get; set; }
    public required string PasswordHashed { get; set; }
}
