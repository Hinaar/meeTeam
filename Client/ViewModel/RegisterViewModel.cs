//using Client.AzureServiceReference;
using Client.Properties;
using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client
{
    public class RegisterViewModel : BaseViewModel, IDataErrorInfo
    {
        public RegisterViewModel()
        {
            DateOfBirth = DateTime.Now;
        }

        ResourceManager rm = Resources.ResourceManager;

        private bool allValid;

        public bool AllValid
        {
            get { return allValid; }
            set { allValid = value; OnPropertyChanged(); }
        }

        public string Email { get; set; }
        //TODO: SecurePassword psw
        public string Password { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        private RelayCommand register;
        private ICommand registerCommand;

        public ICommand RegisterCommand
        {
            get
            {
                if(registerCommand == null)
                {
                    registerCommand = new RelayCommand
                        (
                         x => Register(x),
                         null
                         );
                }
                return registerCommand;

            }
        }
        

        public string Error => this[null];

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;

                if (columnName == null || columnName == nameof(Email)) {
                    //if email is null => email=""
                    if (!Regex.IsMatch(Email ?? "", @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        result = rm.GetString("ErrorMail");
                    }
                }
                if (columnName == null || columnName == nameof(Password))
                {
                    if (!Regex.IsMatch(Password ?? "", @"^(?=.*[a-zA-Z])(?=.*[0-9])"))
                    {
                        result = rm.GetString("ErrorPassword");
                    }
                }
                if (columnName == null || columnName == nameof(Name))
                {
                    if ((Name ?? "").Length < 4)
                    {
                        result = rm.GetString("ErrorName");
                    }
                }
                if (columnName == null || columnName == nameof(DateOfBirth))
                {
                    int age = DateTime.Now.Year - DateOfBirth.Year;
                    if (DateOfBirth > DateTime.Now.AddYears(-age))
                        age--;
                    if (age < 10 || age > 150)
                    {
                        result = rm.GetString("ErrorBirth");
                    }
                }
                //if(columnName == null || columnName == nameof(PhoneNumber))
                //{
                //    if(!Regex.IsMatch(PhoneNumber ?? "", @"/^[0-9\+]{1,}[0-9\-]{3,15}$/"))
                //    {
                //        result = rm.GetString("ErrorPhoneNumber");
                //    }
                //}
                if(columnName == null || columnName == nameof(Country))
                {
                    if((Country??"").Equals(string.Empty))
                    {
                        result = rm.GetString("ErrorCountry");
                    }
                }
                if (columnName == null || columnName == nameof(Address))
                {
                    if ((Country??"").Equals(string.Empty))
                    {
                        result = rm.GetString("ErrorAddress");
                    }
                }


                if (!result.Equals(string.Empty))
                    AllValid = false;
                else if (result.Equals(string.Empty) && columnName == null)
                {
                    AllValid = true;
                }
                else if (columnName != null)
                {
                   bool a = string.IsNullOrEmpty(this.Error);
                }
                    
                return result;
            }
        }

        public bool IsValid
        {
            get { return string.IsNullOrEmpty(this.Error); }
        }

        private async Task Register(object param)
        {
            if (AllValid)
            {
                using (Service1Client sc = new Service1Client()) //AzureServiceClient sc = new AzureServiceClient())
                {
                    sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                    sc.ChannelFactory.Credentials.UserName.Password = "jelszo";
                    bool emailIsTaken = await sc.EmailTakenAsync(Email);
                    if (emailIsTaken)
                    {
                        new DialogWindow(rm.GetString("UniqueEmailDialog")).Show();
                        return;
                    }
                    else
                    {
                        var user = sc.CreateUser(new User
                        {
                            Email = this.Email,
                            Hash = Encoding.UTF8.GetBytes(this.Password),
                            Details = new UserDetail
                            {
                                Country = this.Country,
                                Address = this.Address,
                                DateOfBirth = this.DateOfBirth,
                                Name = this.Name,
                                PhoneNumber = this.PhoneNumber
                            }
                        });
                        if (user == null)
                        {
                            new DialogWindow(rm.GetString("CreateUserDialog")).Show();
                        }
                        else
                        {
                            MainViewModel.Instance.CurrentPage = ApplicationPage.Login;
                        }

                    }

                }
            }
        }
    }
}
