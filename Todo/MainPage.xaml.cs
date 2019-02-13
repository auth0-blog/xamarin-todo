using System;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        protected TodoListViewModel ViewModel
        {
            get { return this.BindingContext as TodoListViewModel; }
            set { this.BindingContext = value; }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ViewModel = new TodoListViewModel(App.DataRepository);
            await ViewModel.LoadData();             
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
