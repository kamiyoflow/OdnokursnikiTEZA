using Microsoft.AspNetCore.Mvc;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Comment;

namespace TEZAProject.API.Controllers
{
     [Route("api/feed/post/comments")]
     public class CommentController : AppBaseController
     {
          private readonly ICommentService _commentService;

          public CommentController(ICommentService commentService)
          {
               _commentService = commentService;
          }

          [HttpGet]
          public async Task<ICollection<CommentDto>> GetPostsCommentsAsync(int postId)
          {
               var postsDto = await _commentService.GetPostsCommentsAsync(postId);
               return postsDto;
          }

          [HttpDelete]
          public async Task<IActionResult> DeleteCommentAsync(int id)
          {
               await _commentService.DeleteCommentAsync(id);
               return Ok();
          }

          [HttpPut]
          public async Task<IActionResult> UpdateCommentAsync(int id, CommentForUpdateDto commentDto)
          {
               await _commentService.UpdateCommentAsync(id, commentDto);
               return Ok(commentDto);
          }

          [HttpPost]
          public async Task<IActionResult> CreatePostAsync(CommentForUpdateDto commentDto)
          {
               await _commentService.CreateCommentAsync(commentDto);
               return Ok(commentDto);
          }
     }
}
