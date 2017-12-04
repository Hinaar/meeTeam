using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        //TODO: SecurePassword psw
        public string Password { get; set; }

        //public ICommand LoginCommand { get; set; }


        //public async Task Login()//(object parameter)
        //{
        //    await RunCommand();
        //}

        private RelayCommand login;

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand
                        (
                        x => Login(),
                        x => CanLogin()
                        );
                }
                return loginCommand;
            }
        }

        private async Task Login()
        {
            await Task.Delay(5000);
            Debug.WriteLine(Email) ;
        }

        private bool CanLogin()
        {
            return true;
        }
    }
}
