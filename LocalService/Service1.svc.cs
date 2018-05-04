using LocalService.Model;
using LocalService.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        #region DbMethod Implementations
        public void InitializeDataBase()
        {
            DbInitializer.Initialize();
        }


        #region User Methods Implementation
        public List<User> GetUsers()
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var user = ctx.Users.Include("Details").ToList();

                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        public List<User> GetUsersOfEvent(int eventId)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var users = ctx.Attends
                        .Where(a => a.Event.EventID == eventId)
                        .Select(a => a.User)
                        .ToList();
                    return users;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var user = ctx.Users.Include(u => u.Details).SingleOrDefault(u => u.UserID == id);
                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return null;
            }
        }

        public User GetUserByPassword(string email, string psw)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var user = ctx.Users.Include(u => u.Details).SingleOrDefault(u => u.Email.Equals(email));
                    bool check = PwdTransformer.Instance.CheckPass(psw, user.Salt, user.Hash);
                    if (check)
                        return user;
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return null;
            }
        }

        public bool EmailTaken(string email)
        {
            using (LocalContext ctx = new LocalContext())
            {
                return ctx.Users.Any(u => u.Email.Equals(email));
            }
        }
        public User GetEventsOwner(int eventId)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Events.SingleOrDefault(ev => ev.EventID == eventId).Owner;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Creates user, with the password given in hash by encoding psw string
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Created user with proper hash and salt</returns>
        public User CreateUser(User user)
        {
            try
            {
                if (EmailTaken(user.Email))
                    return null;

                var passStr = Encoding.UTF8.GetString(user.Hash);
                var tuple = PwdTransformer.Instance.EncryptPass(passStr);
                user.Salt = tuple.Item1;
                user.Hash = tuple.Item2;
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }

        }

        public void DeleteUser(int id)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    User user = ctx.Users.Include(u => u.Details).FirstOrDefault(u => u.UserID == id);
                    ctx.Entry<UserDetail>(user.Details).State = EntityState.Deleted;
                    ctx.Entry<User>(user).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        //TODO: psw change
        public User UpdateUser(int id, User user)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Users.Attach(user);
                    var entry = ctx.Entry(user);
                    entry.State = EntityState.Modified;

                    //password wont change
                    entry.Property(u => u.Salt).IsModified = false;
                    entry.Property(u => u.Hash).IsModified = false;
                    ctx.SaveChanges();
                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        #endregion

        #region Post Methods Implementation
        public List<Post> GetPosts()
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Posts.ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public Post GetPostByID(int id)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Posts.SingleOrDefault(p => p.PostID == id);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<Post> GetPostsByEvent(int eventID)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    //return ctx.Events
                    //    .SingleOrDefault(e => e.EventID == eventID)
                    //    .Posts
                    //    .ToList();
                    // var post = ctx.Posts.SqlQuery("dbo.EventPostsById @p0", eventID).ToList();
                    var post = ctx.Posts.Where(p => p.EventID == eventID).AsNoTracking().ToList();
                    return post;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public Post CreatePost(Post post)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Posts.Add(post);
                    ctx.SaveChanges();
                    return post;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public void DeletePost(int id)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var post = ctx.Posts.SingleOrDefault(p => p.PostID == id);
                    ctx.Posts.Remove(post);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public Post UpdatePost(int id, Post post)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Posts.Attach(post);
                    var entry = ctx.Entry(post);
                    entry.State = EntityState.Modified;
                    ctx.SaveChanges();
                    return post;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        #endregion

        #region Event Methods Implementation
        public List<Event> GetEvents()
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Events.ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public Event GetEventById(int id)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Events.SingleOrDefault(e => e.EventID == id);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<Event> GetEventsOfUser(int userId)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Attends
                        .Where(a => a.UserID == userId)
                        .Select(a => a.Event)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public Event CreateEvent(Event even)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Events.Add(even);
                    ctx.SaveChanges();
                    return even;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public void DeleteEvent(int eventId)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var even = ctx.Events.SingleOrDefault(e => e.EventID == eventId);
                    ctx.Events.Remove(even);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }
        }

        public Event UpdateEvent(int eventId, Event even)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Events.Attach(even);
                    var entry = ctx.Entry(even);
                    entry.State = EntityState.Modified;
                    ctx.SaveChanges();
                    return even;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        #endregion

        #region Attend Methods Implementation
        public bool IsAttend(int userId, int eventId)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Attends
                         .SingleOrDefault(a => a.UserID == userId && a.EventID == eventId)
                         .willAttend;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public void CreateOrUpdateAttend(Attend attend)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    if (ctx.Attends.Any(a => a.UserID == attend.UserID && a.EventID == attend.EventID))
                    {
                        ctx.Attends.Attach(attend);
                        var entry = ctx.Entry(attend);
                        entry.State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    else
                    {
                        if (ctx.Users.Any(u => u.UserID == attend.UserID))
                        {
                            ctx.Attends.Add(attend);
                            ctx.SaveChanges();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public Attend CreateAttend(Attend attend)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Attends.Add(attend);
                    ctx.SaveChanges();
                    return attend;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public void DeleteAttend(int userId, int eventId)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var att = ctx.Attends.SingleOrDefault(a => a.UserID == userId && a.EventID == eventId);
                    ctx.Attends.Remove(att);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public List<UserAttend> GetComplexUsersOfEvent(int eventID)
        {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var query = ctx.Events.Include(e => e.Attends)
                        .SingleOrDefault(e => e.EventID == eventID)
                        .Attends
                        .Select(a =>
                            new UserAttend()
                            {
                                UserName = ctx.Users
                                              .Include(u => u.Details)
                                              .Single(u => u.UserID == a.UserID)
                                              .Details.Name,
                                Attends = a.willAttend
                            })
                        .ToList();
                    return query;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }



        #endregion
        #region DbManagementMethods

        public async Task TruncateDatabase()
        {
            using (LocalContext ctx = new LocalContext())
            {
                string query = string.Empty;

                //get table names
                List<string> tableNames = new List<string> { "Attends", "Coordinate", "Events", "Posts", "Users" };
                //ObjectContext objectContext = ((IObjectContextAdapter)ctx).ObjectContext;
                //ReadOnlyCollection<EntityType> allTypes = objectContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace);
                //foreach (EntityType item in allTypes)
                //{
                //    //assembly name
                //    string typeName =item.fu;
                //    Type type = Type.GetType(typeName);

                //    //func
                //    string sql = ctx.Set(type).ToString();
                //    Regex regex = new Regex(@"FROM \[dbo\]\.\[(?<table>.*)\] AS");
                //    Match match = regex.Match(sql);
                //    tableNames.Add(match.Groups["table"].Value);
                //}

                //core:
              //     List<string> tableNamess = ctx.Model.GetEntityTypes().Select(t => t.Relational().TableName).Where(n => n != "Logs").Distinct().ToList();
                List<string> manyToManyTables = new List<string> {};

                tableNames.ForEach(t => query += $"ALTER TABLE {t} nocheck constraint all;");
                tableNames.ForEach(t => query += $"DELETE FROM {t};"); //truncate csak drop constrainttal megy
                tableNames.Where(t => !manyToManyTables.Contains(t)).ToList().ForEach(t => query += $"DBCC CHECKIDENT ({t}, RESEED, 0);");
                tableNames.ForEach(t => query += $"ALTER TABLE {t} check constraint all;");

                await ctx.Database.ExecuteSqlCommandAsync(query);
            }
            
        }

        public void SeedDatabase()
        {
            DbInitializer.Initialize();
        }

        #endregion
        #endregion
    }
}
