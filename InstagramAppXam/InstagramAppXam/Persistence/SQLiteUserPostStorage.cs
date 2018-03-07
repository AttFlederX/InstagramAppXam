using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using InstagramAppXam.Models;
using InstagramAppXam.ViewModels;

using SQLite;
using Xamarin.Forms;

namespace InstagramAppXam.Persistence
{
    public class SQLiteUserPostStorage : IUserPostStorage
    {
        public SQLiteAsyncConnection MasterConnection { get; private set; }

        public SQLiteUserPostStorage()
        {
            MasterConnection = DependencyService.Get<ISQLiteDB>().GetConnection();
            MasterConnection.CreateTableAsync<UserPost>();
        }

        /// <summary>
        /// Loads the database table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserPost>> LoadDataAsync()
        {
            return await MasterConnection.Table<UserPost>().ToListAsync();
        }

        /// <summary>
        /// Finds a user post by its ID (primary key)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserPost> LoadUserPost(int id)
        {
            return await MasterConnection.FindAsync<UserPost>(id);
        }

        /// <summary>
        /// Finds a user profile by its email
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserPost>> LoadUserPosts(string username)
        {
            var query = MasterConnection.Table<UserPost>().Where(up => (up.Username == username));
            return await query.ToListAsync();
        }


        public async Task<int> InsertAsync(UserPost post)
        {
            return await MasterConnection.InsertAsync(post);
        }

        public async Task<int> UpdateAsync(UserPost post)
        {
            return await MasterConnection.UpdateAsync(post);
        }

        public async Task<int> DeleteAsync(UserPost post)
        {
            return await MasterConnection.DeleteAsync(post);
        }
    }
}
