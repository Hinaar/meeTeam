using Client.ServiceReference;
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
        public User LoggedInUser { get; set; }
        private ObservableCollection<EventViewModel> eventList = new ObservableCollection<EventViewModel>();

        public ObservableCollection<EventViewModel> EventList
        {
            get
            {
                return eventList;
            }
        }

        private EventViewModel selectedEvent;
        public EventViewModel SelectedEvent
        {
            get { return selectedEvent; }
            set {
                selectedEvent = value;
                OnPropertyChanged();
 
            }
        }

        public async void loadEventListAsync()
        {
            using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            {
                var list =await sc.GetEventsAsync();
                foreach (Event even in list)
                {
                    EventList.Add(new EventViewModel(even));
                }
            }
            Increment();
        }

        public async void Increment()
        {
            await Task.Delay(3000);
            foreach (var item in EventList)
            {
                item.Title += "halo";
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

        public InnerViewModel()
        {
           
           loadEventListAsync();
           
        }

        public InnerViewModel(User u)
        {
            LoggedInUser = u;
            loadEventListAsync();
        }
    }
}
