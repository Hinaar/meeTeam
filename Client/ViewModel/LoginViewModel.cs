//using Client.AzureServiceReference;
using Client.Properties;
using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
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
        ResourceManager rm = Resources.ResourceManager;
        public string Email { get; set; }
        //TODO: SecurePassword psw
        public string Password { get; set; }
        #endregion
        //public ICommand LoginCommand { get; set; }


        //public async Task Login()//(object parameter)
        //{
        //    await RunCommand();
        //}

        public LoginViewModel()
        {
          // TempMethodAsync();
        }

        private async Task TempMethodAsync()
        {
            using (Service1Client sc = new Service1Client())
            {
                await sc.TruncateDatabaseAsync();
                await sc.SeedDatabaseAsync();
            }
        }

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
        //TODO: pass user to innerpage
        private async Task Login(object param)
        {
            Debug.WriteLine("command started");
            //await Task.Delay(5000);
            //using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            //{
            using (Service1Client sc = new Service1Client())//AzureServiceClient sc = new AzureServiceClient())
            {
                sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                sc.ChannelFactory.Credentials.UserName.Password = "jelszo";

                DialogWindow tmp;
                var pwdBox = param as PasswordBox;
                var user = await sc.GetUserByPasswordAsync(Email, pwdBox.Password);
                if (user == null)
                {
                    tmp = new DialogWindow(rm.GetString("ErrorLogin"));

                    tmp.ShowDialog();

                }
                else
                {
                    MainViewModel.Instance.User = user;
                    MainViewModel.Instance.CurrentPage = ApplicationPage.Inner;
                }
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
