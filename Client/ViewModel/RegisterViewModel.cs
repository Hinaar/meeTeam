using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client
{
    public class RegisterViewModel : BaseViewModel
    {
        public string Email { get; set; }
        //TODO: SecurePassword psw
        public string Password { get; set; }


    }
}
