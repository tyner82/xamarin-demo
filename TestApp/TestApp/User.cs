﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TestApp
{
    public class User
    {


        // https://swapi.co/api/people/
        //public int id { get; set; }
        public string birth_year { get; set; }
        public string eye_color { get; set; }
        public string[] films { get; set; }
        public string gender { get; set; }
        public string hair_color { get; set; }
        public string height { get; set; }
        public string homeworld { get; set; }
        public string mass { get; set; }
        public string name { get; set; }
        public string skin_colour { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string[] species { get; set; }
        public string[] starships { get; set; }
        public string url { get; set; }
        public string[] vehicles { get; set; }
    }

    public class UserFetcher :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<User> userList = new List<User>();
        public bool isLoading = false;
        public bool isLoaded = false;

        public async void GetUsers(int[] _idArray)
        {
            Console.WriteLine("GetUsers");
            var httpClient = new HttpClient();
            try
            {
                foreach (int idx in _idArray)
                {
                    isLoading = true;
                    string response = await httpClient.GetStringAsync("https://swapi.co/api/people/" + idx);
                    User user = JsonConvert.DeserializeObject<User>(response);
                    userList.Add(user);
                    //Console.WriteLine(userList[userList.Count - 1].eye_color);
                }
                isLoaded = true;
                isLoading = false;
                NotifyPropertyChanged();
            }
            catch (Exception e)
            {
                userList.Add(new User
                {
                    birth_year = "1982",
                    created = "1982",
                    eye_color = "blue",
                    edited = "1982",
                    films = new string[] { "None" },
                    gender = "Male",
                    hair_color = "Blonde",
                    height = "195",
                    homeworld = "Earth",
                    mass = "68kg",
                    name = "Chris Tyner",
                    skin_colour = "Pink",
                    species = new string[] { "Human" },
                    starships = new string[] { "Earth" },
                    url = "https://github.com/tyner82",
                    vehicles = new string[] { "Cobalt", "Tacoma" }
                });
                isLoaded = true;
                NotifyPropertyChanged();
                isLoading = false;
                Console.WriteLine($"error in http: {e}");
                Console.WriteLine($"Count of list: {userList.Count}");
            }
        }
    }
}
