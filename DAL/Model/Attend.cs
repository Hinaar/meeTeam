using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Attend
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int EventID { get; set; }
        public bool willAttend { get; set; }
    }
}