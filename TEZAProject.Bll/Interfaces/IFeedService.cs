using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Post;

namespace TEZAProject.Bll.Interfaces
{
     public interface IFeedService
     {
          Task<ICollection<PostDto>> GetAllPostsAsync(); 
          Task<PostDto> CreatePostAsync(PostForUpdateDto postForUpdateDto);
          Task UpdatePostAsync(int id, PostForUpdateDto postForUpdateDto);
          Task DeletePostAsync(int id);
     }
}
