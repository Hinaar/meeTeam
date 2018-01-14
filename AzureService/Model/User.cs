using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AzureService.Model
{
    [DataContract]
    [Table("Users")]
    public partial class User
    {
        public User()
        {
            Attends = new List<Attend>();
            Events = new List<Event>();
        }

        [Key]
        [DataMember]
        public int UserID { get; set; }


        [DataMember]
        public byte[] Salt { get; set; }

        [DataMember]
        public byte[] Hash { get; set; }

        [DataMember]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("UserID")]
        [DataMember]
        public virtual UserDetail Details { get; set; }



        [DataMember]
        public virtual ICollection<Attend> Attends { get; set; }
        [DataMember]
        public virtual ICollection<Event> Events { get; set; }
    }
}
