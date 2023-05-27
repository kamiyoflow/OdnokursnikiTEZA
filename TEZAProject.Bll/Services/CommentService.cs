using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Comment;
using TEZAProject.Dal.Interfaces;
using TEZAProject.Domain;

namespace TEZAProject.Bll.Services
{
     public class CommentService : ICommentService
     {
          private readonly IRepository _repository;
          private readonly IMapper _mapper;

          public CommentService(IRepository repository, IMapper mapper)
          {
               _repository = repository;
               _mapper = mapper;
          }

          public async Task<CommentDto> CreateCommentAsync(CommentForUpdateDto commentForUpdateDto)
          {
               var comment = _mapper.Map<Comment>(commentForUpdateDto);

               _repository.Add(comment);
               
               var post = await _repository.GetById<Post>(comment.PostId);
               post.Comments.Add(comment);

               await _repository.SaveChangesAsync();

               var commentDto = _mapper.Map<CommentDto>(comment);
               return commentDto;
          }

          public async Task DeleteCommentAsync(int id)
          {
               await _repository.Delete<Comment>(id);
               await _repository.SaveChangesAsync();
          }

          public async Task<ICollection<CommentDto>> GetPostsCommentsAsync(int postId)
          {
               var post = await _repository.GetById<Post>(postId);
               var commentListDto = new List<CommentDto>();
               var allComments = await _repository.GetAll<Comment>();
               var postComments = from comment in allComments
                                  where comment.PostId == post.Id
                                  select comment;
               var postDtoComments = new List<CommentDto>();

               if (post.Comments is not null)
               {
                    foreach (var comment in postComments)
                    {
                         var tmpComment = _mapper.Map<CommentDto>(comment);
                         postDtoComments.Add(tmpComment);
                    }
               }

               return postDtoComments;
          }

          public async Task UpdateCommentAsync(int id, CommentForUpdateDto commentForUpdateDto)
          {
               var comment = _repository.GetById<Post>(id);
               _mapper.Map(commentForUpdateDto, comment);
               await _repository.SaveChangesAsync();
          }
     }
}
