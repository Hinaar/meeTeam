using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace DataService
{
    public class MyUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if(!(userName=="meeteam" && password == "jelszo"))
            {
                throw new FaultException(String.Format("Unknown credentials"));
            }


        }
    }
}