using System;
using System.Collections.Generic;

using System.Net.Http;
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

    public class UserFetcher    {
        public List<User> userList = new List<User>();
        static int[] _idArray = new int[] { 1, 2, 3, 4, 5};
        public bool isLoading = false;
        public bool isLoaded = false;

        public async void GetUsers()
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
            }
            catch
            {
                isLoaded = false;
                isLoading = false;
                Console.WriteLine("error in http");
            }
        }
    }
}
