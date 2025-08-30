using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Application.Dtos
{
    public  record UserCreateUpdateDto(
        [Required]
        string Name,
        [EmailAddress]
        string Email
        );
}
