﻿using Client.ServiceReference;
//using Client.AzureServiceReference;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class EventViewModel : BaseViewModel
    {
        private Event even;
        public Event Even { get => even; }

        private ObservableCollection<UserAttend> participiants;
        public ObservableCollection<UserAttend> Participiants { get { return participiants; } set { participiants = value; OnPropertyChanged(); } }

        private PostListViewModel postListData = new PostListViewModel();

        public PostListViewModel PostListData
        {
            get { return postListData; } set { postListData = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return even.Description; }
            set { even.Description = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get { return even.Title; }
            set { even.Title = value; OnPropertyChanged(); }
        }

        public DateTime FromDate
        {
            get { return even.FromDate;}
            set { even.FromDate = value; OnPropertyChanged(); }
        }

        public DateTime ToDate
        {
            get { return even.ToDate; }
            set { even.ToDate = value; OnPropertyChanged(); }
        }

        public double Longitude
        {
            get { return even.Longitude; }
            set { even.Longitude = value; EventLocation = new Location(value, Latitude, 0.0); OnPropertyChanged(); } //?eleg new nelkul van propchange?
        }

        public double Latitude
        {
            get { return even.Latitude; }
            set { even.Latitude = value; EventLocation = new Location(Longitude, value, 0.0);  OnPropertyChanged(); }
        }


        private Location eventLocation = new Location();
        public Location EventLocation {
            get {
                return eventLocation;
            }
            set
            {
                eventLocation = value;
                OnPropertyChanged();
            }
        }

        public async void loadUserAttendsAsync()
        {
            using (Service1Client sc = new Service1Client())//AzureServiceClient sc = new AzureServiceClient())
            {
                sc.ChannelFactory.Credentials.UserName.UserName = "meeteam";
                sc.ChannelFactory.Credentials.UserName.Password = "jelszo";
                var list = await sc.GetComplexUsersOfEventAsync(even.EventID);
                Participiants = new ObservableCollection<UserAttend>(collection: list);
            }
        }

        public async void loadPostsAsync()
        {
            using (Service1Client asc = new Service1Client())//AzureServiceClient asc = new AzureServiceClient())
            {
                var posts = await asc.GetPostsByEventAsync(Even.EventID);

                foreach (var post in posts)
                {
                    PostListData.PostList.Add(new PostListItemViewModel { Name = post.Writer, Message = post.Text });
                }

                Debug.WriteLine(posts.Count());

            }
        }


        public EventViewModel(Event e)
        {
            even = e;
            //TODO: adatbazisba megcserelni erteket es itt is (db be rosszul van)
            EventLocation = new Location(e.Longitude, e.Latitude, 0.0);
            loadUserAttendsAsync();
            loadPostsAsync();
        }
    }
}
