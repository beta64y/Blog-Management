using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Blog_Management.Services;
using Blog_Management.Database.Repository;

namespace Blog_Management.ApplicationLogic.Validations
{
    internal class UserValidation
    {
        public static bool IsValidName(string Name)
        {
            Regex regex = new Regex(@"[A-Z][a-z]{2,}");

            if (regex.IsMatch(Name) && ValidationServices.IsLengthBetween(Name,3,30))
            {
                return true;
            }         

            return false;
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]{10,30}@code\.edu\.az$");

            if (regex.IsMatch(email) && !UserRepository.IsUserExistByEmail(email))
            {
                return true ;
            }
            return false;
        }
        public static bool IsValidPassword(string text)
        {
            bool upper = false, lower = false, digit = false;

            foreach (char character in text)
            {
                if (char.IsUpper(character)) { upper = true; }
                if (char.IsLower(character)) { lower = true; }
                if (char.IsDigit(character)) { digit = true; }
            }
            if (upper && lower && digit && text.Length >= 8)
            {
                return true;
            }
            return false;


        }
    }
}
