using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Users;
using Blog_Management.Database.Models.Common;

namespace Blog_Management.Database.Models.Inbox
{
    internal class Message : Entity<int>
    {
        private static int IdCounter = 1;
        public User Sender { get; set; } = null;
        public string Text { get; set; }
        public Message(string text)
        {
            Text = text;
            CreationTime = DateTime.Now;
            Id = IdCounter++;
        }
        public Message(User sender, string text)
        {
            Sender = sender;
            Text = text;
            CreationTime = DateTime.Now;
            Id = IdCounter++;
        }
    }
}
