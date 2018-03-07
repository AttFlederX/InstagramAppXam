using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using InstagramAppXam.Models;

namespace InstagramAppXam.ViewModels
{
    public interface IUserPostStorage
    {
        Task<IEnumerable<UserPost>> LoadDataAsync();
        Task<UserPost> LoadUserPost(int id);
        Task<IEnumerable<UserPost>> LoadUserPosts(string username);
        Task<int> InsertAsync(UserPost post);
        Task<int> UpdateAsync(UserPost post);
        Task<int> DeleteAsync(UserPost post);
    }
}
