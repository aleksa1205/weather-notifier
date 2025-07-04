using System.ComponentModel.DataAnnotations;

namespace Domain.Primitives;

public abstract class RootEntity
{
    [Required]
    public required Guid Id { get; set; } = Guid.CreateVersion7();
}
