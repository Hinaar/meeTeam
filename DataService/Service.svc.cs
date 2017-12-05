using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataService.Model;
using System.Diagnostics;
using System.Threading;
using DataService.Security;
using System.Data.Entity;

namespace DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

      

        public int Faszom()
        {
            return 4;
        }
        #region DbMethods Implementations
            #region User Methods Implementation
            public List<User> GetUsers()
            {
                try
                {
                    using (LocalContext ctx = new LocalContext())
                    {
                        return ctx.Users.ToList();
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
                        return ctx.Users.SingleOrDefault(u => u.UserID == id);
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
                    var user = ctx.Users.SingleOrDefault(u => u.Email.Equals(email));
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
    

            public User GetEventsOwner(int eventId)
            {
                try
                {
                    using (LocalContext ctx = new LocalContext())
                    {
                       return ctx.Events.SingleOrDefault(ev=> ev.EventID == eventId).Owner;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return null;
                }
            }

            public void CreateUser(User user)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
                
            }

            public void DeleteUser(int id)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var user = ctx.Users.SingleOrDefault(u => u.UserID == id);
                    if (user != null)
                    {
                        ctx.Users.Remove(user);
                        ctx.SaveChanges();
                    }
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

            #region  Coordinate Methods Implementation
            public List<Coordinate> GetCoordinates()
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Coordinates.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
            }

            public Coordinate GetCoordinateById(int id)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Coordinates.SingleOrDefault(c => c.CoordinateID == id);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

            public Coordinate GetCoordinateByName(string name)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Coordinates.SingleOrDefault(c => c.LocationName.Equals(name));
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

            public Coordinate GetEventCoordinate(int eventId)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    return ctx.Events.SingleOrDefault(e => e.EventID == eventId).Coordinate;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

            public void CreateCoordinate(Coordinate coordinate)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Coordinates.Add(coordinate);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                
            }
        }

            public void DeleteCoordinate(int id)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    var coord = ctx.Coordinates.SingleOrDefault(c => c.CoordinateID == id);
                    ctx.Coordinates.Remove(coord);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                
            }
        }

            public Coordinate UpdateCoordinate(int id, Coordinate coordinate)
            {
            try
            {
                using (LocalContext ctx = new LocalContext())
                {
                    ctx.Coordinates.Attach(coordinate);
                    ctx.Entry(coordinate).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return coordinate;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
            #endregion
            #region Post Methods Implementation
            public List<Post> GetPosts()
            {
                throw new NotImplementedException();
            }

            public Post GetPostByID(int id)
            {
                throw new NotImplementedException();
            }

            public List<Post> GetPostsByEvent(int eventID)
            {
                throw new NotImplementedException();
            }

            public void CreatePost(Post post)
            {
                throw new NotImplementedException();
            }

            public void DeletePost(int id)
            {
                throw new NotImplementedException();
            }

            public Post UpdatePost(int id, Post post)
            {
                throw new NotImplementedException();
            }
            #endregion
            #region Event Methods Implementation
            public List<Event> GetEvents()
            {
                throw new NotImplementedException();
            }

            public Event GetEventById(int id)
            {
                throw new NotImplementedException();
            }

            public List<Event> GetEventsOfUser(int userId)
            {
                throw new NotImplementedException();
            }

            public void CreateEvent(Event even)
            {
                throw new NotImplementedException();
            }

            public void DeleteEvent(int eventId)
            {
                throw new NotImplementedException();
            }

            public Event UpdateEvent(int eventId, Event even)
            {
                throw new NotImplementedException();
            }
            #endregion
            #region Attend Methods Implementation
            public bool IsAttend(int userId, int eventId)
            {
                throw new NotImplementedException();
            }

            public void DeleteAttend(int userId, int eventId)
            {
                throw new NotImplementedException();
            }
            #endregion
        #endregion
    }
}
