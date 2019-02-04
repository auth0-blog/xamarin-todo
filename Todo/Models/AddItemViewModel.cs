using System;
using System.Windows.Input;
using Todo.Repositories;
using Xamarin.Forms;

namespace Todo.Models
{
    public class AddItemViewModel : ObservableModel
    {
        private readonly TodoDataRepository dataRepository;
        private string todoText;

        public event EventHandler ItemAdded;

        /// <summary>
        /// Command to add a new item to the data
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (!string.IsNullOrWhiteSpace(this.TodoText))
                    {
                        //appRepository.Items.Add(new TodoItem { Title = this.TodoText });
                        ItemAdded?.Invoke(this, new EventArgs());
                    }
                });
            }
        }

        /// <summary>
        /// The new todo item value
        /// </summary>
        public string TodoText
        {
            get { return this.todoText; }
            set { this.todoText = value; NotifyPropertyChanged("TodoText"); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Todo.Models.AddItemViewModel"/> class.
        /// </summary>
        /// <param name="repository">The data repository.</param>
        public AddItemViewModel(TodoDataRepository repository)
        {
            dataRepository = repository;
        }
    }
}
