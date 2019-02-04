using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Todo.Repositories;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class TasksViewModel : ObservableModel
    {
        private readonly TodoDataRepository dataRepository;
        private bool isRefreshing;

        public ICommand TapCommand
        {
            get
            {
                return new Command<TodoItem>(item => item.IsDone = !item.IsDone);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command<TodoItem>(item => this.Todos.Remove(item));
            }
        }

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
        /// Loads the data
        /// </summary>
        public ICommand LoadCommand
        {
            get
            {
                return new Command(async () => await LoadData());
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

        public ObservableCollection<TodoItem> Todos { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Todo.Models.TasksViewModel"/> class.
        /// </summary>
        /// <param name="repository">The todo data repository</param>
        public TasksViewModel(TodoDataRepository repository)
        {
            Todos = new ObservableCollection<TodoItem>();
            dataRepository = repository;
        }

        /// <summary>
        /// Loads data from the server.
        /// </summary>
        private async Task LoadData()
        {
            var items = await dataRepository.LoadData();
            Todos.Clear();
            items.OrderBy(i => i.IsDone).ToList().ForEach(Todos.Add);
        }
        
    }
}
    