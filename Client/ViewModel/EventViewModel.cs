﻿using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class EventViewModel : BaseViewModel
    {
        Event even;

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
            get { return even.FromDate; }
            set { even.FromDate = value; OnPropertyChanged(); }
        }

        public DateTime ToDate
        {
            get { return even.ToDate; }
            set { even.ToDate = value; OnPropertyChanged(); }
        }




        public EventViewModel(Event e)
        {
            even = e;
        }
    }
}