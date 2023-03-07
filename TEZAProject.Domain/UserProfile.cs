using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Domain.Auth;

namespace TEZAProject.Domain
{
     public class UserProfile : BaseEntity
     {
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public int Age { get; set; }
          public int UserId { get; set; }
          public User User { get; set; }
          public string Email { get; set; }
          public DateTime Created { get; set; }

     }
}
