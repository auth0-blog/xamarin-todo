using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Repositories;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        protected TasksViewModel ViewModel
        {
            get { return this.BindingContext as TasksViewModel; }
            set { this.BindingContext = value; }
        }

        public MainPage()
        {
            InitializeComponent();

            ViewModel = new TasksViewModel(new TodoDataRepository());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.RefreshCommand.Execute(null);
        }

        async void AddMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.TapCommand.Execute(e.Item);
        }


    }
}
