using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService.Security;
using System.Text;
using DataService.Model;
using UnitTestProject.ServiceReference1;
using Client;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUsersExisting()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var users = sc.GetUsers();
                if (users == null)
                    Assert.Fail("No users");
                else return;
            }
        }

        [TestMethod]
        public void TableSplittingTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var user = sc.GetUserById(1);
                Assert.IsNotNull(user.Details, "Table splitting failed, no data in details entity");
                return;
            }
        }

        [TestMethod]
        public void EntitySplittingTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var myEv = sc.GetEventById(2);
                Assert.IsNotNull(myEv.LocationName, "Entity splitting failed, no data from Coordinate table");
                return;
            }
        }

        [TestMethod]
        public void LoginTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var user = sc.GetUserByPasswordAsync("bela@meeTeam.hu", "jelszo");
                Assert.IsNotNull(user, "Login failed with correct data");
                return;
            }
        }

        [TestMethod]
        public void LoginFailTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var user = sc.GetUserByPassword("bela@meeTeam.hu", "jelszo2");
                Assert.IsNull(user, "Succesful login, with incorrect data");
                return;
            }
        }

        [TestMethod]
        public void DiffHashGenerationTest()
        {
            var tuple1 = PwdTransformer.Instance.EncryptPass("abc");
            var tuple2 = PwdTransformer.Instance.EncryptPass("abc");

            Assert.IsFalse(Equals(tuple1.Item2, tuple2.Item2));
            return;
        }

        [TestMethod]
        public void RegisterTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {

                var user = new User
                {
                    Email = "test1@mail.hu",
                    Hash = Encoding.UTF8.GetBytes("jelszo"),
                    Details = new UserDetail
                    {
                        Name = "testName",
                        Country = "Austria",
                        Address = "1010 hmm u.",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "+36101234567",
                    }
                };
                Assert.IsFalse(sc.EmailTaken("test1@mail.hu"), "Email already taken");
                user = sc.CreateUser(user);
                Assert.IsNotNull(user, "Create failed");

                return;
            }
        }

        [TestMethod]
        public void ComplexUserAttendTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var list = sc.GetComplexUsersOfEvent(2);
                foreach (var attendant in list)
                {
                    if (attendant.UserName.Equals("Bela"))
                        Assert.IsFalse(!attendant.Attends);
                }
                return;
            }
        }

        [TestMethod]
        public void NewEventCommandTest()
        {
            InnerViewModel ivm = new InnerViewModel();
            int eventCount = ivm.EventList.Count;
            ivm.NewEventCommand.Execute(null);
            Assert.IsTrue(eventCount < ivm.EventList.Count,"New event was not created");
            return;
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            using (ServiceClient sc = new ServiceClient())
            {
                var user = sc.GetUserById(4);
                Assert.IsNotNull(user, "User doues not exist");

                sc.DeleteUser(4);
                user = sc.GetUserById(4);

                Assert.IsNull(user, "User was not deleted");
                return;

            }
        }
    }
}
