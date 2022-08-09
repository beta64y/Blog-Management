using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Common;
using Blog_Management.Database.Models.Users;
using Blog_Management.Database.Models.Inbox;
using Blog_Management.Database.Models.Shares;

namespace Blog_Management.Database.Models.Shares
{
    internal class Chirp : Entity<string>
    {
        
        public string Title { get; set; }
        public string ChirpText { get; set; }
        public User User { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Comment> Comments { get; set; }
        public int Likes { get; set; } = 0; 
        public Chirp(string title, string chirpText, User user ,string id)
        {
            Id = id;
            Title = title;
            ChirpText = chirpText;
            User = user;
            CreationTime = DateTime.Now;
            
            
        }
    }
}
