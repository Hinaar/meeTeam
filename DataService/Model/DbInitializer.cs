using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            using (LocalContext ctx = new LocalContext())
            {
                try
                {
                    if (ctx.Users.Any())
                        return;

                    ctx.Users.Add(new User()
                    {
                        Name = "Bela",
                        DateOfBirth = new DateTime(1996, 7, 21),
                        Email = "bela@meeTeam.hu",
                        Salt = null,
                        Hash = "pass"
                    });
                    ctx.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}
