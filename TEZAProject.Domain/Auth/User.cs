﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Domain.Auth
{
     public class User : IdentityUser<int>
     {
          public UserProfile UserProfile { get; set; }
     }
}
