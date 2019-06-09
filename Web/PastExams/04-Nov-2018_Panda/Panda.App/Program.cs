using SIS.MvcFramework;
using System;

namespace Panda.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
