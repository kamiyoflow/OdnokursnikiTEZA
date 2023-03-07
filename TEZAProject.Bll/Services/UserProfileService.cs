using AutoMapper;
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

namespace TEZAProject.Bll.Services
{
     public class UserProfileService : IUserProfileService
     {
          private readonly IUserProfileRepository _userProfileRepository;
          private readonly IMapper _mapper;

          public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper)
          {
               _userProfileRepository = userProfileRepository;
               _mapper = mapper;
          }

          public async Task<UserProfileDto> CreateUserProfileAsync(AccountForRegistrationDto userProfileForUpdateDto)
          {
               var userProfile = _mapper.Map<UserProfile>(userProfileForUpdateDto);

               _userProfileRepository.Add(userProfile);
               await _userProfileRepository.SaveChangesAsync();

               var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);
               return userProfileDto;
          }

          public async Task DeleteUserProfileAsync(int id)
          {
               await _userProfileRepository.Delete<UserProfile>(id);
               await _userProfileRepository.SaveChangesAsync();
          }

          public async Task<ICollection<UserProfileListDto>> GetAllUserProfileAsync()
          {
               var userProfileList = await _userProfileRepository.GetAll<UserProfile>();
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
               var userProfile = await _userProfileRepository.GetById<UserProfile>(id);
               var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);
               return userProfileDto;
          }

          public async Task UpdateUserProfileAsync(int id, UserProfileForUpdateDto userProfileForUpdateDto)
          {
               var userProfile = await _userProfileRepository.GetById<UserProfile>(id);
               _mapper.Map(userProfileForUpdateDto, userProfile);
               await _userProfileRepository.SaveChangesAsync();
          }
     }
}
