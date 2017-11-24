
using System.Runtime.Serialization;

namespace DataService.Model
{
    [DataContract]
    public class Coordinate
    {
        [DataMember]
        public int CoordinateID { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public string LocationName { get; set; }
    }
}