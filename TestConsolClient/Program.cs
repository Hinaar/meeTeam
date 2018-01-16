using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestConsolClient.AzureReference;
using TestConsolClient.ServiceReference1;

namespace TestConsolClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            
            using (AzureServiceClient sc = new AzureServiceClient())
            {
                //sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                //sc.ChannelFactory.Credentials.UserName.Password = "jelszo";
                
                var users = sc.GetUserById(3);
                Console.WriteLine(users.Email);
                Console.WriteLine(users.Details.Address);
                var post = sc.GetPostsByEvent(2);
                foreach (var item in post)
                {
                    Console.WriteLine(item.Text);
                }
               

            }
          //  AsyncTest();

            Console.ReadLine();
        }

        private static async void AsyncTest()
        {
            
            //using (ServiceClient sc = new ServiceClient())
            //{
            //    //var users = await sc.GetUsersOfEventAsync(1);
            //    //foreach (User user in users)
            //    //{
            //    //    Console.WriteLine($"{user.Email} , {user.Hash}");
            //    //}

            //    var complex = await sc.GetComplexUsersOfEventAsync(1);
            //    foreach (var item in complex)
            //    {
            //        Console.WriteLine(item.UserName + " - " + item.Attends);
            //    }

            //}
        }
    }
}
