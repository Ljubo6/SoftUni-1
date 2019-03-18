using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05.Date_Modifier
{
    public class DateModifier
    {
        public static int GetDifferenceBetweenTwoDates(string one, string two)
        {
            DateTime firstDate = DateTime.ParseExact(one, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(two, "yyyy MM dd", CultureInfo.InvariantCulture);
            
            return Math.Abs((firstDate - secondDate).Days);
        }
    }
}
