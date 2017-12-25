﻿using Client.ServiceReference;
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
