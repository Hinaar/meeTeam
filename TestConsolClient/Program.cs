using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestConsolClient.ServiceReference;

namespace TestConsolClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            
            using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            {
               sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                sc.ChannelFactory.Credentials.UserName.Password = "jelszo";
                
                var users = sc.GetUserById(3);
                Console.WriteLine(users.Email);
                Console.WriteLine(users.Details.Address);
                Console.ReadKey();
                //sc.DeleteUser(4);
                Console.ReadKey();
                var mas = sc.GetUserById(3);
                if (mas==null)
                    Console.WriteLine("kitorlodott");
                else
                    Console.WriteLine("nem torlodott");


                //foreach (var item in users)
                //{
                //    Console.WriteLine(item.Email);
                //    Console.WriteLine("\t " + item.Details.Address);
                //}
            }
          //  AsyncTest();

            Console.ReadLine();
        }

        private static async void AsyncTest()
        {
            
            using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            {
                //var users = await sc.GetUsersOfEventAsync(1);
                //foreach (User user in users)
                //{
                //    Console.WriteLine($"{user.Email} , {user.Hash}");
                //}

                var complex = await sc.GetComplexUsersOfEventAsync(1);
                foreach (var item in complex)
                {
                    Console.WriteLine(item.UserName + " - " + item.Attends);
                }

            }
        }
    }
}
