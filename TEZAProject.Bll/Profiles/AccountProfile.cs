using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Account;
using TEZAProject.Domain.Auth;
using AutoMapper;
using TEZAProject.Common.Dtos.UserProfile;

namespace TEZAProject.Bll.Profiles
{
     public class AccountProfile : Profile
     {
          public AccountProfile()
          {
               CreateMap<User, AccountForRegistrationDto>().ReverseMap()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.FirstName.Insert(src.FirstName.Length, src.LastName)));

               //CreateMap<User, UserProfileDto>(MemberList.None)
               //          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
               //          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
          }
     }
}
