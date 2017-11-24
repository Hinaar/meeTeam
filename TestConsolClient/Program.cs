using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadKey();
        }
    }
}
