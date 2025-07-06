using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domain.Primitives;

namespace Domain.Users;
public class User : RootEntity
{
    [Required]
    public required string Email { get; set; }

    [Required]
    public required string City { get; set; }

    [SetsRequiredMembers]
    public User(string email, string city)
    {
        Email = email;
        City = city;
    }
}