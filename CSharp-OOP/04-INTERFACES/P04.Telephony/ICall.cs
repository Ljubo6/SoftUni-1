using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Telephony
{
    public interface ICall
    {
        string Dial(string number);
    }
}
