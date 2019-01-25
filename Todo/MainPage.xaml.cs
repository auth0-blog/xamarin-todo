using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new TasksViewModel();

            Debug.WriteLine("Initializing main page");
        }

        async void AddMenuItem_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
    }
}
