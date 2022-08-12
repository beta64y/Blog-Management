﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Common;
using Blog_Management.Database.Models.Users;
using Blog_Management.Database.Enums;

namespace Blog_Management.Database.Models.Shares
{
    internal class Chirp : Entity<string>
    {
        
        public string Title { get; set; }
        public string ChirpText { get; set; }
        public User User { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public BlogStatus BlogStatus { get; set; } = BlogStatus.Waiting;
        public Chirp(string title, string chirpText, User user ,string id)
        {
            Id = id;
            Title = title;
            ChirpText = chirpText;
            User = user;
            CreationTime = DateTime.Now;
        }
        public Chirp(string title, string chirpText, User user, string id,BlogStatus blogStatus)
        {
            Id = id;
            Title = title;
            ChirpText = chirpText;
            User = user;
            CreationTime = DateTime.Now;
            BlogStatus = blogStatus;
        }
    }
}
