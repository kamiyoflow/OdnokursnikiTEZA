using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Comment;
using TEZAProject.Common.Dtos.Post;
using TEZAProject.Dal.Interfaces;
using TEZAProject.Domain;

namespace TEZAProject.Bll.Services
{
     public class FeedService : IFeedService
     {

          private readonly IRepository _repository;
          private readonly IMapper _mapper;

          public FeedService(IRepository repository, IMapper mapper)
          {
               _repository = repository;
               _mapper = mapper;
          }

          public async Task<PostDto> CreatePostAsync(PostForUpdateDto postForUpdateDto)
          {
               var post = _mapper.Map<Post>(postForUpdateDto);

               _repository.Add(post);
               await _repository.SaveChangesAsync();

               var postDto = _mapper.Map<PostDto>(post);
               return postDto;
          }

          public async Task DeletePostAsync(int id)
          {
               await _repository.Delete<Post>(id);
               await _repository.SaveChangesAsync();
          }

          public async Task<ICollection<PostDto>> GetAllPostsAsync()
          {
               var posts = await _repository.GetAll<Post>();
               
               var postListDto = new List<PostDto>();
               foreach (var post in posts)
               {
                    var tempPost = _mapper.Map<PostDto>(post);
                    var allComments = await _repository.GetAll<Comment>();
                    var postComments = from comment in allComments
                                       where comment.PostId == post.Id
                                       select comment;
                    var postDtoComments = new List<CommentDto>();
                    foreach(var comment in postComments)
                    {

                         var tmpComment = _mapper.Map<CommentDto>(comment);
                         postDtoComments.Add(tmpComment);
                    }

                    foreach(var comment in postDtoComments)
                    {
                        tempPost.Comments.Add(comment);
                    }
                    postListDto.Add(tempPost);
               }
               return postListDto;
          }

          public async Task UpdatePostAsync(int id, PostForUpdateDto postForUpdateDto)
          {
               var post = _repository.GetById<Post>(id);
               _mapper.Map(postForUpdateDto, post);
               await _repository.SaveChangesAsync();
          }
     }
}
