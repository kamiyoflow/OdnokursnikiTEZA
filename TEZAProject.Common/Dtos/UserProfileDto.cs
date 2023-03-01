﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Common.Dtos
{
     public class UserProfileDto
     {
          public int Id { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public int Age { get; set; }
          public DateTime Created { get; set; }
     }
}
