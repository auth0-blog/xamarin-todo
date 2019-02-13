using System;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new TasksViewModel(App.DataRepository);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await (this.BindingContext as TasksViewModel).Initialize();
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
