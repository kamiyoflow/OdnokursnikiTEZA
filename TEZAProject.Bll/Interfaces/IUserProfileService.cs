using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Account;
using TEZAProject.Common.Dtos.UserProfile;

namespace TEZAProject.Bll.Interfaces
{
     public interface IUserProfileService
     {
          Task<UserProfileDto> GetUserProfileAsync(int id);
          Task<ICollection<UserProfileListDto>> GetAllUserProfileAsync();
          Task<UserProfileDto> CreateUserProfileAsync(AccountForRegistrationDto userProfile);
          Task UpdateUserProfileAsync(int id, UserProfileForUpdateDto userProfile);
          Task DeleteUserProfileAsync(int id);
     }
}
