using System;
using System.Collections.Generic;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();

            var viewModel = new AddItemViewModel();
            this.BindingContext = viewModel;

            viewModel.ItemAdded += async (s, e) =>
            {
                await Navigation.PopAsync();
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ItemEntry.Focus();
        }
    }
}
