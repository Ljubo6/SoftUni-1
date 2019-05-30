using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer
{
    public static class Webhost
    {
        public static void Start(IMvcApplication application)
        {
            application.Configure();
        }
    }
}
