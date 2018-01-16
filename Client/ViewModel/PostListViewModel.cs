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

        private List<PostListItemViewModel> postList = new List<PostListItemViewModel>();

        public List<PostListItemViewModel> PostList
        {
            get { return postList; }
            set { postList = value; OnPropertyChanged(); }
        }


    }
}
