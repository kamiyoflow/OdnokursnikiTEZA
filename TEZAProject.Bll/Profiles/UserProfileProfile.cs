﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Account;
using TEZAProject.Common.Dtos.UserProfile;
using TEZAProject.Domain;

namespace TEZAProject.Bll.Profiles
{
     public class UserProfileProfile : Profile
     {
          public UserProfileProfile()
          {
               CreateMap<UserProfile, UserProfileDto>().ReverseMap();
               CreateMap<UserProfile, AccountForRegistrationDto>().ReverseMap();
               CreateMap<UserProfile, UserProfileForUpdateDto>().ReverseMap();
               CreateMap<UserProfile, UserProfileListDto>().ReverseMap();
          }
     }
}
