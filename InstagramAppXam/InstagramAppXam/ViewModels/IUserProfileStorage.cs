using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using InstagramAppXam.Models;

namespace InstagramAppXam.ViewModels
{
    public interface IUserProfileStorage
    {
        Task<IEnumerable<UserProfile>> LoadDataAsync();
        Task<UserProfile> LoadUserProfile(int id);
        Task<UserProfile> LoadUserProfile(string username);
        Task<int> InsertAsync(UserProfile profile);
        Task<int> UpdateAsync(UserProfile profile);
        Task<int> DeleteAsync(UserProfile profile);
    }
}
