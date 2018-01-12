
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        #region DbMethods

        [OperationContract]
        void InitializeDataBase();

        #region User Methods
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        bool EmailTaken(string email);

        [OperationContract]
        List<User> GetUsersOfEvent(int eventId);

        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        User GetUserByPassword(string email, string psw);

        [OperationContract]
        User GetEventsOwner(int eventId);

        [OperationContract]
        User CreateUser(User user);

        [OperationContract]
        void DeleteUser(int id);

        [OperationContract]
        User UpdateUser(int id, User user);


        #endregion

        #region Post Methods
        [OperationContract]
        List<Post> GetPosts();

        [OperationContract]
        Post GetPostByID(int id);

        [OperationContract]
        List<Post> GetPostsByEvent(int eventID);

        [OperationContract]
        Post CreatePost(Post post);

        [OperationContract]
        void DeletePost(int id);

        [OperationContract]
        Post UpdatePost(int id, Post post);

        #endregion

        #region Event Methods
        [OperationContract]
        List<Event> GetEvents();

        [OperationContract]
        Event GetEventById(int id);

        [OperationContract]
        List<Event> GetEventsOfUser(int userId);

        [OperationContract]
        Event CreateEvent(Event even);

        [OperationContract]
        void DeleteEvent(int eventId);

        [OperationContract]
        Event UpdateEvent(int eventId, Event even);


        #endregion

        #region Attend Methods
        [OperationContract]
        bool IsAttend(int userId, int eventId);

        [OperationContract]
        void DeleteAttend(int userId, int eventId);

        [OperationContract]
        List<UserAttend> GetComplexUsersOfEvent(int eventID);
        #endregion
        #endregion
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
