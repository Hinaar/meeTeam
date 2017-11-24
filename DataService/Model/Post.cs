using System;
using System.Runtime.Serialization;

namespace DataService.Model
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int PostID { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public string Writer { get; set; }
    }
}