﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer
{
    public interface IMvcApplication
    {
        void ConfigureServices();
        void Configure();
    }
}
