using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Dial(string number)
        {
            if (number.Any(c => char.IsLetter(c)))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
