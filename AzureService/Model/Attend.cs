using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AzureService.Model
{
    [DataContract]
    public class Attend
    {
        [DataMember]
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [DataMember]
        [Key, Column(Order = 1)]
        public int EventID { get; set; }

        [DataMember]
        public bool willAttend { get; set; }



        [DataMember]
        public virtual Event Event { get; set; }

        [DataMember]
        public virtual User User { get; set; }
    }
}