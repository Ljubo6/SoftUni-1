﻿using SIS.WebServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App
{
    public class Program
    {
        public static void Main()
        {
            Webhost.Start(new StartUp());
        }
    }
}
