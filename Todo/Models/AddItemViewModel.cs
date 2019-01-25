using System;
using System.Windows.Input;
using Todo.Repositories;
using Xamarin.Forms;

namespace Todo.Models
{
    public class AddItemViewModel : ObservableModel
    {
        private TodoDataRepository appRepository;
        private string todoText;

        public event EventHandler ItemAdded;

        /**
         * Adds a new item
         */
        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (!string.IsNullOrWhiteSpace(this.TodoText))
                    {
                        appRepository.Items.Add(new TodoItem { Title = this.TodoText });
                        ItemAdded?.Invoke(this, new EventArgs());
                    }
                });
            }
        }

        public string TodoText
        {
            get { return this.todoText; }
            set { this.todoText = value; NotifyPropertyChanged("TodoText"); }
        }

        public AddItemViewModel()
        {
            appRepository = Application.Current.Resources["Data"] as TodoDataRepository;
        }
    }
}
