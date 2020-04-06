using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "ListView Code Demo";
            Padding = 10;
            int[] ids = new int[] { 1 ,2};
            Users(ids);
        }
        public async void Users(int[] ids)
        {
            var httpClient = new HttpClient();
            List<User> userList = new List<User>();
            foreach (int idx in ids)
            {
                var response = await httpClient.GetStringAsync("https://swapi.co/api/people/" + idx);
                var user = JsonConvert.DeserializeObject<User>(response);
                userList.Add(user);
                Console.WriteLine(userList[userList.Count-1].eye_color);
            }
            listUsers.ItemsSource = userList;

        }

    }
}
