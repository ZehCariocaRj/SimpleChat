﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatClientWPF.Models
{
    class RegisterModel
    {
        public string ErrorMessage { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
    }
}
