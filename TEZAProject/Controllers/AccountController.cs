using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Account;
using TEZAProject.Domain.Auth;

namespace TEZAProject.API.Controllers
{
     [Route("api/account")]
     public class AccountController : AppBaseController
     {
          private readonly UserManager<User> _userManager;
          private readonly SignInManager<User> _signInManager;
          private readonly ILogger<AccountController> _logger;
          private readonly IMapper _mapper;
          private readonly IUserProfileService _userProfileService;

          public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
               ILogger<AccountController> logger, IMapper mapper, IUserProfileService userProfileService)
          {
               _userManager = userManager;
               _signInManager = signInManager;
               _logger = logger;
               _mapper = mapper;
               _userProfileService = userProfileService;
          }

          [AllowAnonymous]
          [HttpPost("register")]
          public async Task<IActionResult> Register([FromBody] AccountForRegistrationDto userDto)
          {
                         _logger.LogInformation($"Registration attempt for {userDto.Email}");

                         var user = _mapper.Map<User>(userDto);
                         var result = await _userManager.CreateAsync(user, userDto.Password);

                         if (!result.Succeeded)
                         {
                              return BadRequest("User registration failed.");
                         }

                         userDto.UserId = user.Id;
                         var profileResult = await _userProfileService.CreateUserProfileAsync(userDto);

                         return Accepted();
          }

          [AllowAnonymous]
          [HttpPost("login")]
          public async Task<IActionResult> Login(AccountForLoginDto userForLoginDto)
          {
               var user = await _userManager.FindByEmailAsync(userForLoginDto.Email);
               var checkingPasswordResult = await _signInManager.PasswordSignInAsync(user, userForLoginDto.Password, false, false);
               
               if (!checkingPasswordResult.Succeeded)
               {
                    return Unauthorized(userForLoginDto);
               }

               return Accepted();
          }
     }
}
