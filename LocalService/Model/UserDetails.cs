using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LocalService.Model

{
    [DataContract]
    [Table("Users")]
    public partial class UserDetail
    {
        [Key]
        public int UserID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Address { get; set; }

        
        public virtual User User { get; set; }
    }
}