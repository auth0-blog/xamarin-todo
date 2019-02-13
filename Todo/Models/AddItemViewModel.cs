using System;
using System.Windows.Input;
using Todo.Repositories;
using Xamarin.Forms;

namespace Todo.Models
{
    public class AddItemViewModel : ObservableModel
    {
        private readonly IDataRepository dataRepository;
        private string todoText;

        public event EventHandler ItemAdded;

        /// <summary>
        /// Handles the command for adding a new item to the collection
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (!string.IsNullOrWhiteSpace(this.TodoText))
                    {                        
                        dataRepository.AddItem(new TodoItem { Title = TodoText });
                        ItemAdded?.Invoke(this, new EventArgs());
                    }
                });
            }
        }

        /// <summary>
        /// Holds the text for the new Todo item
        /// </summary>
        public string TodoText
        {
            get { return todoText; }
            set { todoText = value; NotifyPropertyChanged("TodoText"); }
        }

        /// <summary>
        /// Creates a new instance of AddItemViewModel
        /// </summary>        
        public AddItemViewModel(IDataRepository repository)
        {
            dataRepository = repository;
        }
    }
}
