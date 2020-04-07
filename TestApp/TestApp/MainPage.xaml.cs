using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int[] _apiHelperArray;

        public MainPage()
        {
            InitializeComponent();

            Title = "ListView Code Demo";
            Padding = 10;
            UserFetcher fetcher = new UserFetcher();
            fetcher.GetUsers(new int[] { 1, 2, 3, 4, 5 });
            listUsers.ItemsSource = fetcher.userList;
        }

        void OnCheckHandler(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkie = (CheckBox)sender;
            Console.WriteLine(((CheckBox)sender).AutomationId);
        }

    }
}
