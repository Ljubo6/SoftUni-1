using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.App.ViewModels.InputModels
{
    public class UserLoginInputModel
    {
        [RequiredSis]
        public string Username { get; set; }
        [RequiredSis]
        public string Password { get; set; }
    }
}
