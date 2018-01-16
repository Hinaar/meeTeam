

namespace Client
{
   public  class PostListItemDesignModel : PostListItemViewModel
    {
        //~singleton
        public static PostListItemDesignModel Instance => new PostListItemDesignModel(); 


        public PostListItemDesignModel()
        {
            this.Name = "Bela";
            this.Message = "csodas szoveg nagyon design time ";
        }
    }
}
