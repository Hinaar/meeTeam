using System;

namespace DAL.Model
{
    public class Post
    {
        public int PostID { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }


        public virtual User Poster { get; set; }
    }
}