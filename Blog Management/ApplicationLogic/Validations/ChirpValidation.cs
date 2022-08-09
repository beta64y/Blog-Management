using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Blog_Management.Services;

namespace Blog_Management.ApplicationLogic.Validations
{
    internal class ChirpValidation
    {
        public static bool IsValidChirpTitle(string title)
        {
            if(ValidationServices.IsLengthBetween(title,5,40))
            {
                return true;
            }
            return false;
        }
        
    }
}
