using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Common.Dtos.Account
{
     public class AccountForLoginDto
     {
          [Required]
          public string Email { get; set; }

          [Required]
          public string Password { get; set; }
     }
}
