using Microsoft.AspNetCore.Mvc;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Account;
using TEZAProject.Common.Dtos.UserProfile;

namespace TEZAProject.API.Controllers
{
     [Route("api/users")]
     public class UserProfileController : AppBaseController
     {
          private readonly IUserProfileService _userProfileService;

          public UserProfileController(IUserProfileService userProfileService)
          {
               _userProfileService = userProfileService;
          }


          [HttpGet("{id}")]
          public async Task<UserProfileDto> GetUserProfileAsync(int id)
          {
               var userProfileDto = await _userProfileService.GetUserProfileAsync(id);
               return userProfileDto;
          }

          [HttpGet]
          public async Task<ICollection<UserProfileListDto>> GetAllUserProfileAsync()
          {
               var userProfileDtos = await _userProfileService.GetAllUserProfileAsync();
               return userProfileDtos;
          }

          //[HttpPost]
          //public async Task<IActionResult> CreateUserProfileAsync(AccountForRegistrationDto userDto)
          //{
          //     await _userProfileService.CreateUserProfileAsync(userDto);
          //     return Ok(userDto);
          //}

          [HttpPut]
          public async Task<IActionResult> UpdateUserProfileAsync(int id, UserProfileForUpdateDto userProfileForUpdateDto)
          {
               await _userProfileService.UpdateUserProfileAsync(id, userProfileForUpdateDto);
               return Ok(userProfileForUpdateDto);
          }

          [HttpDelete]
          public async Task<IActionResult> DeleteUserProfileAsync(int id)
          {
               await _userProfileService.DeleteUserProfileAsync(id);
               return Ok();
          }

     }
}
