//using Client.ServiceReference;
using Client.AzureServiceReference;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    public class InnerViewModel : BaseViewModel
    {
        public User LoggedInUser
        {
            get;
            set;
        }
        private ObservableCollection<EventViewModel> eventList = new ObservableCollection<EventViewModel>();

        public ObservableCollection<EventViewModel> EventList
        {
            get
            {
                return eventList;
            }
        }

        private bool isEdit;

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; OnPropertyChanged(); }
        }


        private EventViewModel selectedEvent;
        public EventViewModel SelectedEvent
        {
            get { return selectedEvent; }
            set {
                selectedEvent = value;
                MapCenter = new Location(value.EventLocation);
                OnPropertyChanged();
            }
        }

        //Property to make selectedevents location independent from map movement
        private Location mapCenter;
        public Location MapCenter
        {
            get { return mapCenter; }
            set { mapCenter = value; OnPropertyChanged(); }
        }

        public async void loadEventListAsync()
        {
            using (AzureServiceClient sc = new AzureServiceClient())
            {
                //sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                //sc.ChannelFactory.Credentials.UserName.Password = "jelszo";
                var list =await sc.GetEventsAsync();
                foreach (Event even in list)
                {
                    EventList.Add(new EventViewModel(even));
                }
            }
        }


        private RelayCommand newEvent;
        private ICommand newEventCommand;
        public ICommand NewEventCommand
        {
            get
            {
                if(newEventCommand == null)
                {
                    newEventCommand = new RelayCommand(x=> NewEvent(),null);
                }
                return newEventCommand;
            }
        }

        private async Task NewEvent()
        {
            EventList.Add(new EventViewModel(new Event()));
            SelectedEvent = EventList.Last();
        }

        private RelayCommand editEvent;
        private ICommand editEventCommand;

        public ICommand EditEventCommand
        {
            get
            {
                if(editEventCommand == null)
                {
                    editEventCommand = new RelayCommand(x=> MakeEventEditable(), null);
                }
                return editEventCommand;
            }
            set { editEventCommand = value; }
        }

        private async Task MakeEventEditable()
        {
            IsEdit = true;
        }

        private RelayCommand saveEvent;
        private ICommand saveEventCommand;

        public ICommand SaveEventCommand
        {
            get
            {
                if (saveEventCommand == null)
                {
                    saveEventCommand = new RelayCommand(x => SaveEditedEvent(), null);
                }
                return saveEventCommand;
            }
            set { saveEventCommand = value; }
        }

        private async Task SaveEditedEvent()
        {
            IsEdit = false;
            using (AzureServiceClient asc = new AzureServiceClient())
            {
                  await asc.UpdateEventAsync(SelectedEvent.Even.EventID, SelectedEvent.Even);
            }
        }


        public InnerViewModel()
        {
            //  Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hu-HU");
            MapCenter = new Location(0, 0, 0);
            loadEventListAsync();
           
        }

        public InnerViewModel(User u)
        {
           // MapCenter = new Location(0, 0, 0);
            LoggedInUser = u;
            loadEventListAsync(); 
            
        }
    }
}
