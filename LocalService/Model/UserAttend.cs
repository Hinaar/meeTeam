using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LocalService.Model

{
    [DataContract]
    public class UserAttend
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public bool Attends { get; set; }


    }
}