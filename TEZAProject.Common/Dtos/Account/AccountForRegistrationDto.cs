using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Common.Dtos.Account
{
     public class AccountForRegistrationDto
     {    
          [Required]
          [MaxLength(30)]
          [MinLength(2)]
          public string FirstName { get; set; }

          [Required]
          [MaxLength(30)]
          [MinLength(2)]
          public string LastName { get; set; }

          [Required]
          public int Age { get; set; }

          [Required]
          [MaxLength(30)]
          [MinLength(8)]
          public string Password { get; set; }

          [Required]
          [EmailAddress]
          [MinLength(8)]
          [MaxLength(50)]
          public string Email { get; set; }

          public int? UserId { get; set; }
     }
}
