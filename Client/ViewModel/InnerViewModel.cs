using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class InnerViewModel : BaseViewModel
    {
        private ObservableCollection<EventViewModel> eventList = new ObservableCollection<EventViewModel>();

        public ObservableCollection<EventViewModel> EventList { get { return eventList; } }

        public void loadEventList()
        {
            using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            {
                var list = sc.GetEvents();
                foreach (Event even in list)
                {
                    EventList.Add(new EventViewModel(even));
                }
            }
        }

        public InnerViewModel()
        {
            loadEventList();
        }
    }
}
