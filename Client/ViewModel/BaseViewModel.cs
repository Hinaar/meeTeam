using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
     public class BaseViewModel : INotifyPropertyChanged 
     { 
       
         public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { }; 
 

   
         public void OnPropertyChanged(string name)
         { 
             PropertyChanged(this, new PropertyChangedEventArgs(name)); 
         } 
 
     } 

}
