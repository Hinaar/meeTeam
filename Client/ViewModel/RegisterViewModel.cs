using Client.Properties;
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
        public string Email { get; set; }
        //TODO: SecurePassword psw
        public string Password { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }


        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                
                switch (columnName)
                {
                    case nameof(Email):
                        {
                            //if email is null => email=""
                            if(!Regex.IsMatch(Email??"", @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                                result =rm.GetString("ErrorMail");
                            break;
                        }
                    case nameof(Password):
                        {
                            if (!Regex.IsMatch(Password??"", @"^(?=.*[a-zA-Z])(?=.*[0-9])"))
                                    result = rm.GetString("ErrorPassword");
                            break;
                        }
                    case nameof(Name):
                        {
                            if ((Name ?? "").Length < 4)
                                result = rm.GetString("ErrorName");
                            break;
                        }
                    case nameof(DateOfBirth):
                        {
                            int age = DateTime.Now.Year - DateOfBirth.Year;
                            if (DateOfBirth > DateTime.Now.AddYears(-age))
                                age--;
                            if (age <10 || age > 150)
                                result = rm.GetString("ErrorBirth");
                            break;
                        }
                    case nameof(PhoneNumber):
                        {
                            break;
                        }
                    case nameof(Country):
                        {
                            break;
                        }
                    case nameof(Address):
                        {
                            break;
                        }
                }
                
                return result;
            }
        }
    }
}
