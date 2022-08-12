using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Inbox;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Models.Common;


namespace Blog_Management.Database.Models.Users
{
    internal class User : Entity<int>
    {      
        private  static int IdCounter = 1;
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Updatedat { get; set; } = null;
        public List<Chirp> Chirps { get; set; } = new List<Chirp>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Message> Inbox { get; set; } = new List<Message>();

      



        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = IdCounter++;
            CreationTime = DateTime.Now;
        }
        public User(string firstName, string lastName, string email, string password,int id, DateTime datetime)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = id;
            CreationTime = datetime;
        }
        public virtual string GetInfo()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
