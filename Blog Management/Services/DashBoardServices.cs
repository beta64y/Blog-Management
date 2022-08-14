using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.ApplicationLogic;
using Blog_Management.Database.Models.Inbox;
using Blog_Management.Database.Models.Users;
using Blog_Management.Database.Repository;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Enums;

namespace Blog_Management.Services
{
    internal class DashBoardServices
    {
        
         
        //user
        public static void Update()
        {
            Console.Write("Please enter your password : ");
            string password = Console.ReadLine();
            if (Authentication.GetAccount().Password == password)
            {
                User user = UserRepository.GetUserByEmailAndPassword(Authentication.GetAccount().Email, password);
                Console.Write("(New) ");
                string New_FirstName = AuthenticationServices.GetFirstName();

                Console.Write("(New) ");
                string New_LastName = AuthenticationServices.GetLastName();
                UserRepository.Update(user, New_FirstName, New_LastName);
                Console.WriteLine("Account Updated");

            }
            else
            {
                Console.WriteLine("Email or Password is not True");
            }

        }
        public static void ShowInbox()
        {
            foreach (Message message in Authentication.GetAccount().Inbox)
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine($"{(message.Sender == null ? "System": message.Sender.FirstName + message.Sender.LastName)} : {message.Text}");
                Console.WriteLine($"{message.CreationTime}");
                Console.WriteLine("***********************************************");
            }
        }
        
        //admin
        public static void RemoveUser()
        {
            if (Authentication.GetAccount() is Admin)
            {
                Console.Write("Please enter user's email : ");
                string email = Console.ReadLine();

                if (UserRepository.IsUserExistByEmail(email) && (UserRepository.GetUserByEmail(email) is not Admin))
                {
                    User user = UserRepository.GetUserByEmail(email);
                    
                    UserRepository.Remove(user);
                    Console.WriteLine($"{user.FirstName} {user.LastName} Permanently Deleted");
                    
                

                }
            }
        }      
        public static void UpdateforAdmin()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();
            if (Authentication.GetAccount().Email != email && UserRepository.IsUserExistByEmail(email) && UserRepository.GetUserByEmail(email) is Admin)
            {
                User user = UserRepository.GetUserByEmail(email);
                Console.Write("(New) ");
                string New_FirstName = AuthenticationServices.GetFirstName();

                Console.Write("(New) ");
                string New_LastName = AuthenticationServices.GetLastName();
                UserRepository.Update(user, New_FirstName, New_LastName);
                Console.WriteLine("Account Updated");

            }
            else
            {
                Console.WriteLine("Rules : \n1. An Admin cannot update their own account \n2. The email entered must be valid \n3. The email entered must be Admin ");
            }
        }
        public static void ShowUsers()
        {
            if (Authentication.GetAccount() is Admin)
            {
                foreach (User user in UserRepository.DbContext)
                {
                    Console.WriteLine($"Name : \"{user.FirstName} {user.LastName}\" \nEmail : {user.Email} | Password : {user.Password} | ID : {user.Id} | Register Date : {user.CreationTime}");

                }
            }
            else { Console.WriteLine("Only admin can use this command"); }

        }
        public static void ShowAdmins()
        {
            foreach (User user in UserRepository.DbContext)
            {
                if (user is Admin)
                {
                    Console.WriteLine($"Name : \"{user.FirstName} {user.LastName}\" \nEmail : {user.Email} | Password : {user.Password} | ID : {user.Id} | Register Date : {user.CreationTime}");
                }
            }


        }
        public static void AddAdmin()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();
            if (Authentication.GetAccount().Email != email && UserRepository.IsUserExistByEmail(email) && !(UserRepository.GetUserByEmail(email) is not Admin))
            {
                UserRepository.AddAdmin(UserRepository.GetUserByEmail(email));
            }
            else
            {
                Console.WriteLine("Rules : \n1. An Admin cannot Make admin their own account \n2. The email entered must be valid \n3. The email entered must be User ");
            }
        }
        
        //chirp
        public static void AddChirp()
        {
            string title = GetTitle();
            string text = GetChirpText();
            ChirpRepository.Append(Authentication.GetAccount(), title, text);
            Console.WriteLine("request sent");
        }
        public static void DeleteChirp()
        {
            Console.Write("Please enter chirp's Id : ");
            string id = Console.ReadLine();
            Chirp chirp = ChirpRepository.GetById(id);
            if (chirp != null)
                {
                    Console.Write($"Are you really determined to delete this chirp? ({ChirpRepository.GetById(id).Title})(\"Yes\" or \"No\") : ");
                    string answer = Console.ReadLine();
                    
                if (answer == "Yes") 
                {
                    ChirpRepository.Remove(chirp);
                    Console.WriteLine("Chirp Deleted"); 
                }
                else
                {
                    Console.WriteLine("Prosses Stoped");
                }

            }
            else
            {
               Console.WriteLine("Chirp not found");
            }
            
            
        }
        public static void ShowChirps()
        {
           foreach (Chirp chirp in ChirpRepository.DbContext)
                {
                if(chirp.ChirpStatus == ChirpStatus.Accepted)
                    GetChirp(chirp);
                }
            


        }
        public static void ShowFilteredChirpsWithComments()
        {
            Console.Write("Please write the filter you will use for the search (\"Title\" or \"Firstname\") : ");
            string filter = Console.ReadLine();
            if(filter == "Title")
            {
                SearchChirpByTitle();
            }
            else if(filter == "Firstname")
            {
                SearchChirpByAuthor();
            }
            else
            {
                Console.WriteLine("The filter you entered could not be found");
            }
        }
        public static void ShowActiveAccountChirps()
        {
            List<Chirp> chirpList = ChirpRepository.GetChirpsByUser(Authentication.GetAccount());
            for (int i = 0; i < chirpList.Count; i++)
            {
                GetChirp(chirpList[i]);
            }
        }                                                      
        public static void ShowAuditingChirps()
        {
            List<Chirp> chirps = ChirpRepository.DbContext;
            foreach(Chirp chirp in chirps)
            {
                if(chirp.ChirpStatus == ChirpStatus.Waiting)
                {
                    GetChirp(chirp);
                }
            }
        }
        public static void ApproveChirp()
        {
            Console.Write("Please enter chirp's Code : ");
            string id = Console.ReadLine();
            Chirp chirp = ChirpRepository.GetById(id);

            if (chirp != null && chirp.ChirpStatus == ChirpStatus.Waiting)
            {
                chirp.ChirpStatus = ChirpStatus.Accepted;
                Console.WriteLine("Chirp Approved");
                chirp.User.Inbox.Add(new Message($"Your chirp  ({chirp.Title})({chirp.Id}) Approved"));
            }
            else
            {
                Console.WriteLine("please check Code");
            }
        }
        public static void RejectChirp()
        {
            Console.Write("Please enter chirp's Code : ");
            string id = Console.ReadLine();
            Chirp chirp = ChirpRepository.GetById(id);

            if (chirp != null && chirp.ChirpStatus == ChirpStatus.Waiting)
            {
                chirp.ChirpStatus = ChirpStatus.Rejected;
                Console.WriteLine("Chirp Rejected");
                chirp.User.Inbox.Add(new Message($"Your chirp  ({chirp.Title})({chirp.Id}) Rejected"));
            }
            else
            {
                Console.WriteLine("please check Code");
            }
        }

        //comment
        public static void AddComment()
        {
            Console.Write("Please enter chirp's Code : ");
            string id = Console.ReadLine();
            Chirp chirp = ChirpRepository.GetById(id);

            if (chirp != null && chirp.ChirpStatus == ChirpStatus.Accepted)
            {
                Console.Write("Please enter comment : ");
                string text = Console.ReadLine();
                CommentRepository.Append(Authentication.GetAccount(), text, chirp);
                chirp.User.Inbox.Add(new Message($"({chirp.Id})  (<{chirp.User.FirstName}> <{chirp.User.LastName}>) tərəfindən comment əlavə olundu."));
            }
            else
            {
                Console.WriteLine("no match found");
            }
        }

        //help
        public static void Help()
        {
            // dash board ucun doldurulacaq
        }

        // some tools 
        public static void SearchChirpById()
        {
            Console.Write("Please enter chirp's Code : ");
            string id = Console.ReadLine();
            Chirp chirp = ChirpRepository.GetById(id);

            if (chirp != null && chirp.ChirpStatus == ChirpStatus.Accepted)
            {
                GetChirp(chirp);
            }
            else
            {
                Console.WriteLine("no match found");
            }
        }
        public static void SearchChirpByTitle()
        {
            Console.Write("Please enter chirp's Title : ");
            string title = Console.ReadLine();

            if (ChirpRepository.GetChirpsByTitle(title).Count > 0)
            {
                foreach (Chirp chirp in ChirpRepository.GetChirpsByTitle(title))
                {
                    GetChirp(chirp); 
                }
            }
            else
            {
                Console.WriteLine("no match found");
            }
        }
        public static void SearchChirpByAuthor()
        {
            Console.Write("Please enter firstname of chirp's author  : ");
            string name = Console.ReadLine();
            if (ChirpRepository.GetChirpsByFirstName(name).Count > 0)
            {
                foreach (Chirp chirp in ChirpRepository.GetChirpsByFirstName(name))
                {
                    GetChirp(chirp);
                }
            }
            else
            {
                Console.WriteLine("no match found");
            }
        }   
        private static string GetTitle()
        {
            bool title_wrongChecker = false;
            string title = "";

            while (!ValidationServices.IsLengthBetween(title,10,35))
            {
                if (title_wrongChecker)
                {
                    Console.WriteLine($"The Chirp title you entered is incorrect, the length is greater than 10 and less than 35.");
                }
                Console.Write($"Enter Chirp title : ");
                title = Console.ReadLine();
                title_wrongChecker = true;
            }
            return title;
        }
        private static string GetChirpText()
        {
            bool chirp_text_wrongChecker = false;
            string chirp_text = "";

            while (!ValidationServices.IsLengthBetween(chirp_text, 10, 400))
            {
                if (chirp_text_wrongChecker)
                {
                    Console.WriteLine($"The Chirp Text you entered is incorrect, the length is greater than 10 and less than 400.");
                }
                Console.Write($"Enter Chirp Text : ");
                chirp_text = Console.ReadLine();
                chirp_text_wrongChecker = true;
            }
            return chirp_text;
        }
        private static void GetChirp(Chirp chirp)
        {
            Console.WriteLine("***************************************\n");
            Console.WriteLine($"{chirp.User.FirstName} {chirp.User.LastName} say that :\n");
            Console.WriteLine($"{chirp.Title}\n");
            OutputTextDesiner($"{chirp.ChirpText}\n", 50);
            Console.WriteLine($"{chirp.CreationTime.ToString("MM/dd/yyyy")}\n");
            Console.WriteLine($"{chirp.Id}\n");
            Console.WriteLine("***************************************\n");
            GetChirpComments(chirp);
            
            
        }
        private static void GetChirpComments(Chirp chirp)
        {
            List<Comment> comments = CommentRepository.GetCommentsByChirp(chirp);
            for(int i = 0; i < comments.Count; i++)
            {
                Console.WriteLine($" {i+1}* [{comments[i].CreationTime.ToString("MM/dd/yyyy")}] [{comments[i].User.FirstName} {comments[i].User.LastName}] : {comments[i].CommentText}");
            }
            Console.WriteLine("***************************************\n");
        }
        private static void OutputTextDesiner(string text ,int charcount)
        {
            int z = 0;
            string[] textArray =text.Split(" ");
            for (int i = 0; i < textArray.Length; i++)
            {
                Console.Write(textArray[i] + " ");
                z += textArray[i].Length;
                if (z > charcount)
                {
                    z = 0;
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

    }
}
