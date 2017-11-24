using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    [DataContract]
    public class User
    {
        public User()
        {
            Attends = new List<Attend>();
            Events = new List<Event>();
        }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        [MaxLength(450)]
        [EmailAddress]
        public string Email { get; set; }

        [DataMember]
        public byte[] Salt { get; set; }

        [DataMember]
        public string Hash { get; set; }



        [DataMember]
        public virtual ICollection<Attend> Attends{ get; set; }
        [DataMember]
        public virtual ICollection<Event> Events { get; set; }
    }
}
