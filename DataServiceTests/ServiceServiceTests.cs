using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataService.Tests
{
    [TestClass()]
    public class ServiceServiceTests
    {
      

        [TestMethod()]
        public void GetUserByIdTest()
        {
            ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient();
            try
            {
                var user = sc.GetUserById(1);
                Debug.WriteLine(user);
                if (user == null)
                    Assert.Fail("nulluser");
                else
                    Assert.Fail("nem null user");
            }
            catch(KeyNotFoundException e)
            {
                StringAssert.Contains(e.Message, "ID");
                return;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.Fail("No Exception was thrown");
        }
    }
}