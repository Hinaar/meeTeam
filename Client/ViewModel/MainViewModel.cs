using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class MainViewModel : BaseViewModel
    {
        private static MainViewModel instance;

        private MainViewModel() { currentPage = ApplicationPage.Login; }

        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainViewModel();
                return instance;
            }
        }

        private ApplicationPage currentPage;
        public ApplicationPage CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }



    }
}
