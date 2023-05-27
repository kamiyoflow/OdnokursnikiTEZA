using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Common.Dtos.Account;
using TEZAProject.Common.Dtos.UserProfile;
using TEZAProject.Dal.Interfaces;
using TEZAProject.Domain;
using TEZAProject.Domain.Auth;

namespace TEZAProject.Bll.Services
{
     public class UserProfileService : IUserProfileService
     {
          private readonly IRepository _repository;
          private readonly IMapper _mapper;
          private readonly UserManager<User> _userManager;

          public UserProfileService(IRepository repository, IMapper mapper, UserManager<User> userManager)
          {
               _repository = repository;
               _mapper = mapper;
               _userManager = userManager;
          }

          public async Task<UserProfileDto> CreateUserProfileAsync(AccountForRegistrationDto userProfileForUpdateDto)
          {
               var userProfile = _mapper.Map<UserProfile>(userProfileForUpdateDto);

               userProfile.User = await _userManager.FindByIdAsync(userProfile.UserId.ToString());

               _repository.Add(userProfile);
               await _repository.SaveChangesAsync();

               var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);
               return userProfileDto;
          }

          public async Task DeleteUserProfileAsync(int id)
          {
               await _repository.Delete<UserProfile>(id);
               await _repository.SaveChangesAsync();
          }

          public async Task<ICollection<UserProfileListDto>> GetAllUserProfileAsync()
          {
               var userProfileList = await _repository.GetAll<UserProfile>();
               var userProfileListDto = new List<UserProfileListDto>();
               foreach(UserProfile profile in userProfileList)
               {
                    var tempDto = _mapper.Map<UserProfileListDto>(profile);
                    userProfileListDto.Add(tempDto);
               }
               return userProfileListDto;
          }

          public async Task<UserProfileDto> GetUserProfileAsync(int id)
          {
               var userProfile = await _repository.GetById<UserProfile>(id);
               var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);
               return userProfileDto;
          }

          public async Task UpdateUserProfileAsync(int id, UserProfileForUpdateDto userProfileForUpdateDto)
          {
               var userProfile = await _repository.GetById<UserProfile>(id);
               _mapper.Map(userProfileForUpdateDto, userProfile);
               await _repository.SaveChangesAsync();
          }
     }
}
