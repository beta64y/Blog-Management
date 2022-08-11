﻿using System;
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
       
        public static User Append(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password);
            Add(user);
            user.Inbox.Add(new Message("Welcome , Your request has been read and approved"));
            return user;
        }
        public static void Remove(User user)
        {
            foreach(Comment comment in user.Comments)
            {
                CommentRepository.Remove(comment);
            }
            foreach (Chirp chirp in user.Chirps)
            {
                ChirpRepository.Remove(chirp);
            }
            Delete(user);
        }

        public static void Update(User user, string firstName, string lastName)
        {
            user.FirstName = firstName;
            user.LastName = lastName;   
            user.Updatedat = DateTime.Now;
        }


        public static bool IsUserExistByEmailAndPassword(string email ,string password)
        {
            foreach (User user in DbContext)
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
            foreach (User user in DbContext)
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
            foreach (User user in DbContext)
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
            foreach (User user in DbContext)
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
                Add(new Admin(user.FirstName, user.LastName, user.Email, user.Password,user.Id,user.CreationTime));
                Delete(user);
            
        }
        
            //new Admin("Yahya", "Camalzade", "Camalzadeyahya1@gmail.com", "Yahya123");
            //new Admin("Yahya", "Camalzade", "Camalzadeyahya2@gmail.com", "Yahya123");
             //new User("Yahya", "Camalzade", "Camalzadeyahya3@gmail.com", "Yahya123");
             //new User("Yahya", "Camalzade", "Camalzadeyahya4@gmail.com", "Yahya123");
        



    }
}
