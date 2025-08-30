using System.ComponentModel.DataAnnotations;

namespace UA.Application.Dtos
{
    public record UserEmailUpdateDto(    
        [Required]
        [EmailAddress]
        string Email
        );

    
}
