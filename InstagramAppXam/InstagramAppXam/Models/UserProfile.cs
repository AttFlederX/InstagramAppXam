using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using SQLite;

namespace InstagramAppXam.Models
{
    public class UserProfile
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
        public string Gender { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
        public string Image { get; set; }

       // public ObservableCollection<UserPost> PostList { get; set; }
    }
}
