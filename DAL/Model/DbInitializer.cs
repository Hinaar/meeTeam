using DataService.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            using (LocalContext ctx = new LocalContext())
            {
                try
                {
                    //if (ctx.Users.Any())
                    //    return;

                    //PwdTransformer tr = new PwdTransformer();
                    //var tuple = tr.EncryptPass("jelszo");
                    //ctx.Users.Add(new User()
                    //{
                    //    Name = "Bela",
                    //    DateOfBirth = new DateTime(1996, 7, 21),
                    //    Email = "bela@meeTeam.hu",
                    //    Salt = tuple.Item1,
                    //    Hash = tuple.Item2
                    //});
                    //ctx.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}
