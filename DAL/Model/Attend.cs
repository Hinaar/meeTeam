using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.Model
{
    public class Attend
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int EventID { get; set; }

        public bool willAttend { get; set; }



        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}