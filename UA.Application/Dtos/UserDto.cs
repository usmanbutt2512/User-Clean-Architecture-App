
using System.ComponentModel.DataAnnotations;

namespace UA.Application.Dtos
{
    public record UserDto(
        Guid Id,
        [Required]
        string Name,
        [EmailAddress]
        string Email,        
        DateTime CreatedAt);
}
