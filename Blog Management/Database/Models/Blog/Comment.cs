using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Common;
using Blog_Management.Database.Models.Inbox;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Models.Users;

namespace Blog_Management.Database.Models.Shares
{
    internal class Comment : Entity<int>
    {
        public User User { get; set; }
        public string CommentText { get; set; }
        public Chirp Chirp { get; set; }
    }
}
