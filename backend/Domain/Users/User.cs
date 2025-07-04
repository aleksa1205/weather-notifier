using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain.Users;
public class User : RootEntity
{
    [Required]
    public required string Email { get; set; }

    [Required]
    public required string City { get; set; }
}