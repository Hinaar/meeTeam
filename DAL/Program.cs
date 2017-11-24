using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DbInitializer.Initialize();
            Console.ReadKey();
        }

        
    }
}
