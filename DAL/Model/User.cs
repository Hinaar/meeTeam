using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class User
    {
        public User()
        {
            Attends = new List<Attend>();
            Events = new List<Event>();
        }

        public int UserID { get; set; }

        
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(450)]
        [EmailAddress]
        public string Email { get; set; }

        public byte[] Salt { get; set; }

        public byte[] Hash { get; set; }



        public virtual ICollection<Attend> Attends{ get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
