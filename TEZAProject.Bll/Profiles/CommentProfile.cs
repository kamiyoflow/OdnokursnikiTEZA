using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Comment;
using TEZAProject.Domain;

namespace TEZAProject.Bll.Profiles
{
     public class CommentProfile : Profile
     {
          public CommentProfile()
          {
               CreateMap<Comment, CommentDto>().ReverseMap();
               CreateMap<Comment, CommentForUpdateDto>().ReverseMap();
          }
     }
}
