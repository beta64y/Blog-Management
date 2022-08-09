using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Management.Services
{
    internal class ValidationServices
    {
        public static bool IsLengthBetween(string text, int start, int end)
        {
            return text.Length >= start && text.Length < end;
        }
    }
}
