using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace InstagramAppXam.Models
{
    public class UserPost
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get => Date.ToLongDateString(); }

        [MaxLength(255)]
        public string Image { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
