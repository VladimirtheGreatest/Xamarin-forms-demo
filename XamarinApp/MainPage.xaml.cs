using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Girl> girls = new ObservableCollection<Girl>();
        public ObservableCollection<Girl> Girls { get { return girls; } } 
        public MainPage()
        {
            InitializeComponent();
            Login();
        }
        public async void Login()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApiKey", "xrbv1myVu2ZBoHqEBe1odwlIqXVnBkd6YFibJk2q7kVjxrNRuzZpUbGdBJOKlBO");
            var response = await httpClient.GetStringAsync("https://meetmeapi20200626171452.azurewebsites.net/api/Girls/GetGirls?includeDetails=false");
            var data = JsonConvert.DeserializeObject<ObservableCollection<Girl>>(response);       

            foreach (var girl in data)
            {
                girls.Add(girl);
            }

            GirlsView.ItemsSource = girls;
        }
    }
}
