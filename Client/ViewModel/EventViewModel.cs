using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class EventViewModel : INotifyPropertyChanged
    {
        Event even;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Description
        {
            get { return even.Description; }
            set { even.Description = value; OnPropertyChanged(); }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyname=null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public EventViewModel(Event e)
        {
            even = e;
        }
    }
}
