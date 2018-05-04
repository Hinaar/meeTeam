
using LocalService.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalService.Model
{
    public class DbInitializer
    {
        //TODO: meg parat folvenni ide
        public static void Initialize()
        {
            using (LocalContext ctx = new LocalContext())
            {
                try
                {
                    if (ctx.Users.Any())
                        return;

                    var tuple = PwdTransformer.Instance.EncryptPass("jelszo2");

                    ctx.Users.Add(new User()
                    {
                       
                        Email = "bela@meeTeam.hu",
                        Salt = tuple.Item1,
                        Hash = tuple.Item2,
                        Details = new UserDetail()
                        {
                            Name = "Bela",
                            DateOfBirth = new DateTime(1996, 7, 21),
                            PhoneNumber = "+36201234567",
                            Country = "Hungary",
                            Address = "1020 Budapest Meeteam u. 10"
                        }
                    });

                    tuple = PwdTransformer.Instance.EncryptPass("jelszo2");
                    ctx.Users.Add(new User()
                    {

                        Email = "abc@cba.hu",
                        Salt = tuple.Item1,
                        Hash = tuple.Item2,
                        Details = new UserDetail()
                        {
                            Name = "Abc",
                            DateOfBirth = new DateTime(1993, 7, 21),
                            PhoneNumber = "+36200123456",
                            Country = "Hungary",
                            Address = "1120 Budapest Meam u. 12"
                        }
                    });

                    tuple = PwdTransformer.Instance.EncryptPass("jelszo2");
                    ctx.Users.Add(new User()
                    {
                        Email = "Pesta@meeTeam.hu",
                        Salt = tuple.Item1,
                        Hash = tuple.Item2,
                        Details = new UserDetail()
                        {
                            Name = "Pest A",
                            DateOfBirth = new DateTime(1993, 7, 21),
                            PhoneNumber = "+36202345678",
                            Country = "Hungary",
                            Address = "1121 Győr Meow u. 2"
                        }
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
