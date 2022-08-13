using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Users;
using Blog_Management.Database.Repository.Common;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Models.Inbox;


namespace Blog_Management.Database.Repository
{
    internal class UserRepository : Repository<User , int>
    {
        static UserRepository()
        {
            SeedUsers();
        }

        public static void SeedUsers()
        {
            UserRepository.DbContext.Add(new User("Yahya", "Camalzade", "YahyaCamalzade1@code.edu.az", "Yahya123"));
            UserRepository.DbContext.Add(new User("Yahya", "Camalzade", "YahyaCamalzade2@code.edu.az", "Yahya123"));
            UserRepository.DbContext.Add(new User("Yahya", "Camalzade", "YahyaCamalzade3@code.edu.az", "Yahya123"));
            UserRepository.DbContext.Add(new Admin("Yahya", "Camalzade", "YahyaCamalzade4code.edu.az", "Yahya123"));
            UserRepository.DbContext.Add(new Admin("Yahya", "Camalzade", "YahyaCamalzade5@code.edu.az", "Yahya123"));


        }
        public static User Append(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password);
            UserRepository.DbContext.Add(user);
            user.Inbox.Add(new Message("Welcome , Your request has been read and approved"));
            return user;
        }
        public static void Remove(User user)
        {
            foreach (Chirp chirp in ChirpRepository.GetChirpsByUser(user))
            {
                ChirpRepository.DbContext.Remove(chirp);

            }
            foreach (Comment comment in CommentRepository.GetCommentsByUser(user))
            {
                CommentRepository.DbContext.Remove(comment);
            }
            UserRepository.DbContext.Remove(user);
            
        }

        public static void Update(User user, string firstName, string lastName)
        {
            user.FirstName = firstName;
            user.LastName = lastName;   
            user.Updatedat = DateTime.Now;
        }


        public static bool IsUserExistByEmailAndPassword(string email ,string password)
        {
            foreach (User user in UserRepository.DbContext)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }

            }
            return false;
        }


        public static bool IsUserExistByEmail(string email)
        {
            foreach (User user in UserRepository.DbContext)
            {
                if (user.Email == email)
                {
                    return true;
                }

            }
            return false;
        }


        public static User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in UserRepository.DbContext)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }


        public static User GetUserByEmail(string email)
        {
            foreach (User user in UserRepository.DbContext)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }


        public static void AddAdmin(User user)
        {
            UserRepository.DbContext.Add(new Admin(user.FirstName, user.LastName, user.Email, user.Password,user.Id,user.CreationTime));
            UserRepository.DbContext.Remove(user);
            
        }
        
        




    }
}
