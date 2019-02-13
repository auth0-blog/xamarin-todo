using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.Repositories;
using Xamarin.Forms;

namespace Todo.Models
{
    public class TasksViewModel : ObservableModel
    {
        private IDataRepository dataRepository;
        private bool isRefreshing;

        /// <summary>
        /// Handles Tap events on the Todo items
        /// </summary>
        public ICommand TapCommand
        {
            get
            {
                return new Command<TodoItem>(item => item.IsDone = !item.IsDone);
            }
        }

        /// <summary>
        /// Handles delete commands on the todo items
        /// </summary>
        public ICommand DeleteCommand
        {
            get
            {
                return new Command<TodoItem>(async (item) =>
                {
                    var todos = await dataRepository.RemoveItem(item);
                    ApplyData(todos);
                });
            }
        }

        /// <summary>
        /// Refreshes the Todo data
        /// </summary>
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await LoadData();
                    IsRefreshing = false;
                });
            }
        }

        /// <summary>
        /// Returns true if data is being loaded from the repository
        /// </summary>
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.isRefreshing = value; NotifyPropertyChanged("IsRefreshing"); }
        }


        /// <summary>
        /// The list of Todo items in an observable collection
        /// </summary>
        public ObservableCollection<TodoItem> Todos { get; private set; }

        /// <summary>
        /// Creates a new instance of TasksViewModel
        /// </summary>        
        public TasksViewModel(IDataRepository repository)
        {
            this.dataRepository = repository;
        }

        /// <summary>
        /// Initializes the view model and its data
        /// </summary>        
        public async Task LoadData()
        {
            ApplyData(await dataRepository.GetData());
        }

        /// <summary>
        /// Updates the todo item within the data repository
        /// </summary>
        private async Task UpdateDoneStatus(TodoItem item)
        {
            await dataRepository.UpdateItem(item);
        }

        /// <summary>
        /// Applies the specified list of todo items to the observable collection, and notifies subscribers
        /// </summary>        
        private void ApplyData(IEnumerable<TodoItem> data)
        {
            Todos = new ObservableCollection<TodoItem>(data);
            NotifyPropertyChanged("Todos");
        }
    }
}
