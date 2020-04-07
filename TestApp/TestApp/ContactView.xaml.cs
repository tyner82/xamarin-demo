using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactView : ViewCell
    {
        public static readonly BindableProperty NameProperty =
          BindableProperty.Create("ContactCard", typeof(string), typeof(ContactView), "Contact");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public ContactView()
        {

            Name = "test";
            InitializeComponent();
            //test.Text = MainPage.fetcher.userList.Count>0?MainPage.fetcher.userList[0].name:"";
        }
    }
}
