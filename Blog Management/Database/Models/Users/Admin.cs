using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Inbox;

namespace Blog_Management.Database.Models.Users
{
    internal class Admin : User
    {
        
        public Admin(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {
        
        }
        public Admin(string firstName, string lastName, string email, string password,int id,DateTime datetime)
            : base(firstName, lastName, email, password,id,datetime)
        {

        }
        public override string GetInfo()
        {
            return $"{FirstName} {LastName} {Email}";
        } 
    }
}
