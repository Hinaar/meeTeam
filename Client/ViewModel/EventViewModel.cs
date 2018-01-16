//using Client.ServiceReference;
using Client.AzureServiceReference;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class EventViewModel : BaseViewModel
    {
        private Event even;
        public Event Even { get => even; }

        public ObservableCollection<UserAttend> Participiants { get; set; }

        public string Description
        {
            get { return even.Description; }
            set { even.Description = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get { return even.Title; }
            set { even.Title = value; OnPropertyChanged(); }
        }

        public DateTime FromDate
        {
            get { return even.FromDate;}
            set { even.FromDate = value; OnPropertyChanged(); }
        }

        public DateTime ToDate
        {
            get { return even.ToDate; }
            set { even.ToDate = value; OnPropertyChanged(); }
        }

        private Location eventLocation = new Location();
        public Location EventLocation {
            get {
                return eventLocation;
            }
            set
            {
                eventLocation = value;
                OnPropertyChanged();
            }
        }

        public async void loadUserAttendsAsync()
        {
            using (AzureServiceClient sc = new AzureServiceClient())
            {
                //sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                //sc.ChannelFactory.Credentials.UserName.Password = "jelszo";
                var list = await sc.GetComplexUsersOfEventAsync(even.EventID);
                Participiants = new ObservableCollection<UserAttend>(collection: list);
            }
        }


        public EventViewModel(Event e)
        {
            even = e;
            //TODO: adatbazisba megcserelni erteket es itt is (db be rosszul van)
            EventLocation = new Location(e.Longitude, e.Latitude, 0.0);
            loadUserAttendsAsync();
        }
    }
}
