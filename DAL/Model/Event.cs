using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Event
    {
        public Event()
        {
            Attends = new List<Attend>();
            Posts = new List<Post>();
        }

        public int EventID { get; set; }

        public string Title { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Description { get; set; }

        public int CoordinateID { get; set; }




        public virtual ICollection<Attend> Attends { get; set; }

        public virtual User Owner { get; set; }

        public virtual Coordinate Coordinate { get; set; }

        public virtual ICollection<Post> Posts{ get; set; }
    }
}
