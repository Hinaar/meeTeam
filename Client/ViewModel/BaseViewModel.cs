using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
     public class BaseViewModel : INotifyPropertyChanged 
     { 
       
         public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { }; 
 

   
         //public void OnPropertyChanged(string name)
         //{ 
         //    PropertyChanged(this, new PropertyChangedEventArgs(name)); 
         //}

        protected void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    } 

}
