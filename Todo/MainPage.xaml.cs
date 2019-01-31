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
        }

        async void AddMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
        
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((TasksViewModel)this.BindingContext).TapCommand.Execute(e.Item);
        }
    }
}
