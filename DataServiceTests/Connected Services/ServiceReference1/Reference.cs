﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataServiceTests.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        DataService.CompositeType GetDataUsingDataContract(DataService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<DataService.CompositeType> GetDataUsingDataContractAsync(DataService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InitializeDataBase", ReplyAction="http://tempuri.org/IService/InitializeDataBaseResponse")]
        void InitializeDataBase();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InitializeDataBase", ReplyAction="http://tempuri.org/IService/InitializeDataBaseResponse")]
        System.Threading.Tasks.Task InitializeDataBaseAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsers", ReplyAction="http://tempuri.org/IService/GetUsersResponse")]
        DataService.Model.User[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsers", ReplyAction="http://tempuri.org/IService/GetUsersResponse")]
        System.Threading.Tasks.Task<DataService.Model.User[]> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsersOfEvent", ReplyAction="http://tempuri.org/IService/GetUsersOfEventResponse")]
        DataService.Model.User[] GetUsersOfEvent(int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsersOfEvent", ReplyAction="http://tempuri.org/IService/GetUsersOfEventResponse")]
        System.Threading.Tasks.Task<DataService.Model.User[]> GetUsersOfEventAsync(int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUserById", ReplyAction="http://tempuri.org/IService/GetUserByIdResponse")]
        DataService.Model.User GetUserById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUserById", ReplyAction="http://tempuri.org/IService/GetUserByIdResponse")]
        System.Threading.Tasks.Task<DataService.Model.User> GetUserByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUserByPassword", ReplyAction="http://tempuri.org/IService/GetUserByPasswordResponse")]
        DataService.Model.User GetUserByPassword(string email, string psw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUserByPassword", ReplyAction="http://tempuri.org/IService/GetUserByPasswordResponse")]
        System.Threading.Tasks.Task<DataService.Model.User> GetUserByPasswordAsync(string email, string psw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEventsOwner", ReplyAction="http://tempuri.org/IService/GetEventsOwnerResponse")]
        DataService.Model.User GetEventsOwner(int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEventsOwner", ReplyAction="http://tempuri.org/IService/GetEventsOwnerResponse")]
        System.Threading.Tasks.Task<DataService.Model.User> GetEventsOwnerAsync(int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateUser", ReplyAction="http://tempuri.org/IService/CreateUserResponse")]
        void CreateUser(DataService.Model.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateUser", ReplyAction="http://tempuri.org/IService/CreateUserResponse")]
        System.Threading.Tasks.Task CreateUserAsync(DataService.Model.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteUser", ReplyAction="http://tempuri.org/IService/DeleteUserResponse")]
        void DeleteUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteUser", ReplyAction="http://tempuri.org/IService/DeleteUserResponse")]
        System.Threading.Tasks.Task DeleteUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateUser", ReplyAction="http://tempuri.org/IService/UpdateUserResponse")]
        DataService.Model.User UpdateUser(int id, DataService.Model.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateUser", ReplyAction="http://tempuri.org/IService/UpdateUserResponse")]
        System.Threading.Tasks.Task<DataService.Model.User> UpdateUserAsync(int id, DataService.Model.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPosts", ReplyAction="http://tempuri.org/IService/GetPostsResponse")]
        DataService.Model.Post[] GetPosts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPosts", ReplyAction="http://tempuri.org/IService/GetPostsResponse")]
        System.Threading.Tasks.Task<DataService.Model.Post[]> GetPostsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPostByID", ReplyAction="http://tempuri.org/IService/GetPostByIDResponse")]
        DataService.Model.Post GetPostByID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPostByID", ReplyAction="http://tempuri.org/IService/GetPostByIDResponse")]
        System.Threading.Tasks.Task<DataService.Model.Post> GetPostByIDAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPostsByEvent", ReplyAction="http://tempuri.org/IService/GetPostsByEventResponse")]
        DataService.Model.Post[] GetPostsByEvent(int eventID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPostsByEvent", ReplyAction="http://tempuri.org/IService/GetPostsByEventResponse")]
        System.Threading.Tasks.Task<DataService.Model.Post[]> GetPostsByEventAsync(int eventID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreatePost", ReplyAction="http://tempuri.org/IService/CreatePostResponse")]
        DataService.Model.Post CreatePost(DataService.Model.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreatePost", ReplyAction="http://tempuri.org/IService/CreatePostResponse")]
        System.Threading.Tasks.Task<DataService.Model.Post> CreatePostAsync(DataService.Model.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeletePost", ReplyAction="http://tempuri.org/IService/DeletePostResponse")]
        void DeletePost(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeletePost", ReplyAction="http://tempuri.org/IService/DeletePostResponse")]
        System.Threading.Tasks.Task DeletePostAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdatePost", ReplyAction="http://tempuri.org/IService/UpdatePostResponse")]
        DataService.Model.Post UpdatePost(int id, DataService.Model.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdatePost", ReplyAction="http://tempuri.org/IService/UpdatePostResponse")]
        System.Threading.Tasks.Task<DataService.Model.Post> UpdatePostAsync(int id, DataService.Model.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEvents", ReplyAction="http://tempuri.org/IService/GetEventsResponse")]
        DataService.Model.Event[] GetEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEvents", ReplyAction="http://tempuri.org/IService/GetEventsResponse")]
        System.Threading.Tasks.Task<DataService.Model.Event[]> GetEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEventById", ReplyAction="http://tempuri.org/IService/GetEventByIdResponse")]
        DataService.Model.Event GetEventById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEventById", ReplyAction="http://tempuri.org/IService/GetEventByIdResponse")]
        System.Threading.Tasks.Task<DataService.Model.Event> GetEventByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEventsOfUser", ReplyAction="http://tempuri.org/IService/GetEventsOfUserResponse")]
        DataService.Model.Event[] GetEventsOfUser(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEventsOfUser", ReplyAction="http://tempuri.org/IService/GetEventsOfUserResponse")]
        System.Threading.Tasks.Task<DataService.Model.Event[]> GetEventsOfUserAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateEvent", ReplyAction="http://tempuri.org/IService/CreateEventResponse")]
        DataService.Model.Event CreateEvent(DataService.Model.Event even);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateEvent", ReplyAction="http://tempuri.org/IService/CreateEventResponse")]
        System.Threading.Tasks.Task<DataService.Model.Event> CreateEventAsync(DataService.Model.Event even);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteEvent", ReplyAction="http://tempuri.org/IService/DeleteEventResponse")]
        void DeleteEvent(int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteEvent", ReplyAction="http://tempuri.org/IService/DeleteEventResponse")]
        System.Threading.Tasks.Task DeleteEventAsync(int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateEvent", ReplyAction="http://tempuri.org/IService/UpdateEventResponse")]
        DataService.Model.Event UpdateEvent(int eventId, DataService.Model.Event even);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateEvent", ReplyAction="http://tempuri.org/IService/UpdateEventResponse")]
        System.Threading.Tasks.Task<DataService.Model.Event> UpdateEventAsync(int eventId, DataService.Model.Event even);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsAttend", ReplyAction="http://tempuri.org/IService/IsAttendResponse")]
        bool IsAttend(int userId, int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsAttend", ReplyAction="http://tempuri.org/IService/IsAttendResponse")]
        System.Threading.Tasks.Task<bool> IsAttendAsync(int userId, int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteAttend", ReplyAction="http://tempuri.org/IService/DeleteAttendResponse")]
        void DeleteAttend(int userId, int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteAttend", ReplyAction="http://tempuri.org/IService/DeleteAttendResponse")]
        System.Threading.Tasks.Task DeleteAttendAsync(int userId, int eventId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetComplexUsersOfEvent", ReplyAction="http://tempuri.org/IService/GetComplexUsersOfEventResponse")]
        DataService.Model.UserAttend[] GetComplexUsersOfEvent(int eventID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetComplexUsersOfEvent", ReplyAction="http://tempuri.org/IService/GetComplexUsersOfEventResponse")]
        System.Threading.Tasks.Task<DataService.Model.UserAttend[]> GetComplexUsersOfEventAsync(int eventID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : DataServiceTests.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<DataServiceTests.ServiceReference1.IService>, DataServiceTests.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public DataService.CompositeType GetDataUsingDataContract(DataService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<DataService.CompositeType> GetDataUsingDataContractAsync(DataService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public void InitializeDataBase() {
            base.Channel.InitializeDataBase();
        }
        
        public System.Threading.Tasks.Task InitializeDataBaseAsync() {
            return base.Channel.InitializeDataBaseAsync();
        }
        
        public DataService.Model.User[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<DataService.Model.User[]> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public DataService.Model.User[] GetUsersOfEvent(int eventId) {
            return base.Channel.GetUsersOfEvent(eventId);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.User[]> GetUsersOfEventAsync(int eventId) {
            return base.Channel.GetUsersOfEventAsync(eventId);
        }
        
        public DataService.Model.User GetUserById(int id) {
            return base.Channel.GetUserById(id);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.User> GetUserByIdAsync(int id) {
            return base.Channel.GetUserByIdAsync(id);
        }
        
        public DataService.Model.User GetUserByPassword(string email, string psw) {
            return base.Channel.GetUserByPassword(email, psw);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.User> GetUserByPasswordAsync(string email, string psw) {
            return base.Channel.GetUserByPasswordAsync(email, psw);
        }
        
        public DataService.Model.User GetEventsOwner(int eventId) {
            return base.Channel.GetEventsOwner(eventId);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.User> GetEventsOwnerAsync(int eventId) {
            return base.Channel.GetEventsOwnerAsync(eventId);
        }
        
        public void CreateUser(DataService.Model.User user) {
            base.Channel.CreateUser(user);
        }
        
        public System.Threading.Tasks.Task CreateUserAsync(DataService.Model.User user) {
            return base.Channel.CreateUserAsync(user);
        }
        
        public void DeleteUser(int id) {
            base.Channel.DeleteUser(id);
        }
        
        public System.Threading.Tasks.Task DeleteUserAsync(int id) {
            return base.Channel.DeleteUserAsync(id);
        }
        
        public DataService.Model.User UpdateUser(int id, DataService.Model.User user) {
            return base.Channel.UpdateUser(id, user);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.User> UpdateUserAsync(int id, DataService.Model.User user) {
            return base.Channel.UpdateUserAsync(id, user);
        }
        
        public DataService.Model.Post[] GetPosts() {
            return base.Channel.GetPosts();
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Post[]> GetPostsAsync() {
            return base.Channel.GetPostsAsync();
        }
        
        public DataService.Model.Post GetPostByID(int id) {
            return base.Channel.GetPostByID(id);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Post> GetPostByIDAsync(int id) {
            return base.Channel.GetPostByIDAsync(id);
        }
        
        public DataService.Model.Post[] GetPostsByEvent(int eventID) {
            return base.Channel.GetPostsByEvent(eventID);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Post[]> GetPostsByEventAsync(int eventID) {
            return base.Channel.GetPostsByEventAsync(eventID);
        }
        
        public DataService.Model.Post CreatePost(DataService.Model.Post post) {
            return base.Channel.CreatePost(post);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Post> CreatePostAsync(DataService.Model.Post post) {
            return base.Channel.CreatePostAsync(post);
        }
        
        public void DeletePost(int id) {
            base.Channel.DeletePost(id);
        }
        
        public System.Threading.Tasks.Task DeletePostAsync(int id) {
            return base.Channel.DeletePostAsync(id);
        }
        
        public DataService.Model.Post UpdatePost(int id, DataService.Model.Post post) {
            return base.Channel.UpdatePost(id, post);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Post> UpdatePostAsync(int id, DataService.Model.Post post) {
            return base.Channel.UpdatePostAsync(id, post);
        }
        
        public DataService.Model.Event[] GetEvents() {
            return base.Channel.GetEvents();
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Event[]> GetEventsAsync() {
            return base.Channel.GetEventsAsync();
        }
        
        public DataService.Model.Event GetEventById(int id) {
            return base.Channel.GetEventById(id);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Event> GetEventByIdAsync(int id) {
            return base.Channel.GetEventByIdAsync(id);
        }
        
        public DataService.Model.Event[] GetEventsOfUser(int userId) {
            return base.Channel.GetEventsOfUser(userId);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Event[]> GetEventsOfUserAsync(int userId) {
            return base.Channel.GetEventsOfUserAsync(userId);
        }
        
        public DataService.Model.Event CreateEvent(DataService.Model.Event even) {
            return base.Channel.CreateEvent(even);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Event> CreateEventAsync(DataService.Model.Event even) {
            return base.Channel.CreateEventAsync(even);
        }
        
        public void DeleteEvent(int eventId) {
            base.Channel.DeleteEvent(eventId);
        }
        
        public System.Threading.Tasks.Task DeleteEventAsync(int eventId) {
            return base.Channel.DeleteEventAsync(eventId);
        }
        
        public DataService.Model.Event UpdateEvent(int eventId, DataService.Model.Event even) {
            return base.Channel.UpdateEvent(eventId, even);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.Event> UpdateEventAsync(int eventId, DataService.Model.Event even) {
            return base.Channel.UpdateEventAsync(eventId, even);
        }
        
        public bool IsAttend(int userId, int eventId) {
            return base.Channel.IsAttend(userId, eventId);
        }
        
        public System.Threading.Tasks.Task<bool> IsAttendAsync(int userId, int eventId) {
            return base.Channel.IsAttendAsync(userId, eventId);
        }
        
        public void DeleteAttend(int userId, int eventId) {
            base.Channel.DeleteAttend(userId, eventId);
        }
        
        public System.Threading.Tasks.Task DeleteAttendAsync(int userId, int eventId) {
            return base.Channel.DeleteAttendAsync(userId, eventId);
        }
        
        public DataService.Model.UserAttend[] GetComplexUsersOfEvent(int eventID) {
            return base.Channel.GetComplexUsersOfEvent(eventID);
        }
        
        public System.Threading.Tasks.Task<DataService.Model.UserAttend[]> GetComplexUsersOfEventAsync(int eventID) {
            return base.Channel.GetComplexUsersOfEventAsync(eventID);
        }
    }
}
