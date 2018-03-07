using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using InstagramAppXam.Models;
using InstagramAppXam.ViewModels;

using SQLite;
using Xamarin.Forms;

namespace InstagramAppXam.Persistence
{
    /// <summary>
    /// An SQLite user database management class
    /// </summary>
    public class SQLiteUserProfileStorage : IUserProfileStorage
    {
        public SQLiteAsyncConnection MasterConnection { get; private set; }


        public SQLiteUserProfileStorage()
        {
            MasterConnection = DependencyService.Get<ISQLiteDB>().GetConnection();
            MasterConnection.CreateTableAsync<UserProfile>();
        }

        /// <summary>
        /// Loads the database table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfile>> LoadDataAsync()
        {
            return await MasterConnection.Table<UserProfile>().ToListAsync();
        }

        /// <summary>
        /// Finds a user profile by its ID (primary key)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserProfile> LoadUserProfile(int id)
        {
            return await MasterConnection.FindAsync<UserProfile>(id);
        }

        /// <summary>
        /// Finds a user profile by its email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserProfile> LoadUserProfile(string username)
        {
            var query = MasterConnection.Table<UserProfile>().Where(up => (up.Username == username));
            return await query.FirstOrDefaultAsync();
        }


        public async Task<int> InsertAsync(UserProfile profile)
        {
            return await MasterConnection.InsertAsync(profile);
        }

        public async Task<int> UpdateAsync(UserProfile profile)
        {
            return await MasterConnection.UpdateAsync(profile);
        }

        public async Task<int> DeleteAsync(UserProfile profile)
        {
            return await MasterConnection.DeleteAsync(profile);
        }
    }
}
