

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Client
{
   public  class PostListDesignModel : PostListViewModel
    {
        //~singleton
        public static PostListDesignModel Instance => new PostListDesignModel(); 


        public PostListDesignModel()
        {
            PostList = new ObservableCollection<PostListItemViewModel>
            {
                new PostListItemViewModel
                {
                    Name ="bela",
                    Message ="designt time data for postlist"
                },
                new PostListItemViewModel
                {
                    Name ="Pesta",
                    Message ="2: designt time data for postlist"
                },
                new PostListItemViewModel
                {
                    Name ="bela2",
                    Message ="oh designt time data for postlist"
                },
                new PostListItemViewModel
                {
                    Name ="belac",
                    Message ="asdasddesignt time data for postlist"
                },
                new PostListItemViewModel
                {
                    Name ="bela",
                    Message ="designt time data for postlistcyxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
                },
                 new PostListItemViewModel
                {
                    Name ="bela",
                    Message ="designt time data for postlist"
                },
                new PostListItemViewModel
                {
                    Name ="Pesta",
                    Message ="2: designt time data for postlist"
                },
                new PostListItemViewModel
                {
                    Name ="bela2",
                    Message ="oh designt time data for postlist"
                },
            };
        }
    }
}
