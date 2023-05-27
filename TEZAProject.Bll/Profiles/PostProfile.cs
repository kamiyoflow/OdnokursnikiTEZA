using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Post;
using TEZAProject.Domain;

namespace TEZAProject.Bll.Profiles
{
     public class PostProfile : Profile
     {
          public PostProfile()
          {
               CreateMap<Post, PostDto>().ReverseMap();
               CreateMap<Post, PostForUpdateDto>().ReverseMap();
          }

     }
}
