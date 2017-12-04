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
                Console.WriteLine(sc.Faszom());

                Console.ReadKey();
                var users = sc.GetUsers();
                foreach (var item in users)
                {
                    Console.WriteLine(item.Email);
                }
            }
            AsyncTest();

            Console.ReadLine();
        }

        private static async void AsyncTest()
        {
            
            using (ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient())
            {
                var users = await sc.GetUsersOfEventAsync(1);
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Email} , {user.Hash}");
                }
                
            }
        }
    }
}
