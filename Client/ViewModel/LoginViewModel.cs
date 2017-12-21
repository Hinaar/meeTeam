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
    public class LoginViewModel : BaseViewModel
    {
        #region Properties
        public string Email { get; set; }
        //TODO: SecurePassword psw
        public string Password { get; set; }
        #endregion
        //public ICommand LoginCommand { get; set; }


        //public async Task Login()//(object parameter)
        //{
        //    await RunCommand();
        //}

        #region Commands
        private RelayCommand login;
        private RelayCommand registerPage;

        private ICommand loginCommand;
        private ICommand registerPageCommand;

        //LoginCommand = new RelayParameterizedCommand(async (Parameter) => await Login(Parameter));   : anonym async task
        //TODO: code behind solution
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand
                        (
                        x => Login(x),
                        x => CanLogin()
                        );
                }
                return loginCommand;
            }
        }

        public ICommand RegisterPageCommand
        {
            get
            {
                if(registerPageCommand == null)
                {
                    registerPageCommand = new RelayCommand(x=>RegisterPage(x));
                }
                return registerPageCommand;
            }
        }

   
        #endregion
        //TODO: login
        private async Task Login(object param)
        {
            await Task.Delay(3000);
            using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            {
                var pwdBox = param as PasswordBox;
                var user = await sc.GetUserByPasswordAsync(Email, pwdBox.Password);
                if (user == null)
                    MessageBox.Show("Invalid email or password");
                else
                    MainViewModel.Instance.CurrentPage = ApplicationPage.Inner;
                //MainViewModel.Instance.CurrentPage = new InnerViewModel(user);
            }

        }

        private void RegisterPage(object x)
        {
            MainViewModel.Instance.CurrentPage = ApplicationPage.Register;
        }

        private bool CanLogin()
        {
            return true;
        }
    }
}
