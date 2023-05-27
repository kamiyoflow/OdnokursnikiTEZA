using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Comment;

namespace TEZAProject.Bll.Interfaces
{
     public interface ICommentService
     {
          Task<ICollection<CommentDto>> GetPostsCommentsAsync(int postId);
          Task<CommentDto> CreateCommentAsync(CommentForUpdateDto commentForUpdateDto);
          Task UpdateCommentAsync(int id, CommentForUpdateDto commentForUpdateDto);
          Task DeleteCommentAsync(int id);
     }
}
