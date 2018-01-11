using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    [DataContract]
    public class Event
    {
        public Event()
        {
            Attends = new List<Attend>();
            Posts = new List<Post>();
        }

        [DataMember]
        public int EventID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public DateTime ToDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public string LocationName { get; set; }




        [DataMember]
        public virtual ICollection<Attend> Attends { get; set; }

        [DataMember]
        public virtual User Owner { get; set; }

        [DataMember]
        public virtual ICollection<Post> Posts{ get; set; }
    }
}
