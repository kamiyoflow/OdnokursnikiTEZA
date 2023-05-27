using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Post;

namespace TEZAProject.API.Controllers
{
     [Route("api/feed")]
     public class FeedController : AppBaseController
     {
          private readonly IFeedService _feedService;

          public FeedController(IFeedService feedService, IMapper mapper)
          {
               _feedService = feedService;
          }

          [HttpGet]
          public async Task<ICollection<PostDto>> GetAllPostsAsync()
          {
               var postsDto = await _feedService.GetAllPostsAsync();
               return postsDto;
          }

          [HttpDelete]
          public async Task<IActionResult> Delete(int id)
          {
               await _feedService.DeletePostAsync(id);
               return Ok();
          }

          [HttpPut]
          public async Task<IActionResult> UpdatePostAsync(int id, PostForUpdateDto postDto)
          {
               await _feedService.UpdatePostAsync(id, postDto);
               return Ok(postDto);
          }

          [HttpPost]
          public async Task<IActionResult> CreatePostAsync(PostForUpdateDto postDto)
          {
               await _feedService.CreatePostAsync(postDto);
               return Ok(postDto);
          }
     }
}
