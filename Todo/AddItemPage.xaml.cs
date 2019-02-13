using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemViewModel ViewModel
        {
            get { return BindingContext as AddItemViewModel; }
            set { BindingContext = value; }
        }

        public AddItemPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel = new AddItemViewModel(App.DataRepository);

            ViewModel.ItemAdded += async (s, e) =>
            {
                await Navigation.PopAsync();
            };

            ItemEntry.Focus();
        }
    }
}
