using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class PostListViewModel : BaseViewModel
    {

        private ObservableCollection<PostListItemViewModel> postList = new ObservableCollection<PostListItemViewModel>();

        public ObservableCollection<PostListItemViewModel> PostList
        {
            get { return postList; }
            set { postList = value; OnPropertyChanged(); }
        }


    }
}
