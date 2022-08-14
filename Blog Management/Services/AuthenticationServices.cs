using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.ApplicationLogic.Validations;

namespace Blog_Management.Services
{
    internal class AuthenticationServices
    {
        public static string GetFirstName()
        {

            bool name_wrongChecker = false;
            string name = "";

            while (!UserValidation.IsValidName(name))
            {
                if (name_wrongChecker)
                {
                    Console.WriteLine($"The FirstName you entered is incorrect, make sure the FirstName contains only letters,\nthe first letter is capitalized, and the length is greater than 3 and less than 30.");
                }
                Console.Write($"Enter FirstName :");
                name = Console.ReadLine();
                name_wrongChecker = true;
            }
            return name;
        }
        public static string GetLastName()
        {

            bool name_wrongChecker = false;
            string name = "";

            while (!UserValidation.IsValidName(name))
            {
                if (name_wrongChecker)
                {
                    Console.WriteLine($"The LastName you entered is incorrect, make sure the LastName contains only letters,\nthe first letter is capitalized, and the length is greater than 3 and less than 30.");
                }
                Console.Write($"Enter LastName :");
                name = Console.ReadLine();
                name_wrongChecker = true;
            }
            return name;
        }
        public static string GetEmail()
        {
            bool email_wrongChecker = false;
            string email = "";

            while (!UserValidation.IsValidEmail(email))
            {
                if (email_wrongChecker)
                {
                    Console.WriteLine("The email you entered is incorrect, Receipent - can only be composed of letters and \nnumbers, the total length can be min 10 max 30, Separator - there must be an @ in \nbetween Domain - can only end with code.edu.com.\n\"E-mail must be unique\"");
                }
                Console.Write("Enter Email :");
                email = Console.ReadLine();
                email_wrongChecker = true;
            }
            return email;
        }
        public static string GetPassword()
        {
            bool password_wrongChecker = false;
            bool re_password_wrongChecker = false;
            string password = "";
            string re_password = "";

            while (!UserValidation.IsValidPassword(password))
            {
                if (password_wrongChecker)
                {
                    Console.WriteLine("The password you entered is incorrect, Password - Must contain at least one uppercase \nletter, one lowercase letter and a number, and length cannot be less than 8");
                }
                Console.Write("Enter Password:");
                password = Console.ReadLine();
                password_wrongChecker = true;
            }


            while (!(password == re_password))
            {
                if (re_password_wrongChecker)
                {
                    Console.WriteLine("The password you re-entered is incorrect,Re-entered Password should be the same as the password ");
                }
                Console.WriteLine("Re-Enter Password :");
                re_password = Console.ReadLine();
                re_password_wrongChecker = true;
            }
            return password;
        }
    }
}
