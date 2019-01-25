using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Todo.Models
{
    public class TasksViewModel
    {
        public ICommand TapCommand
        {
            get
            {
                return new Command<TodoItem>(item => item.IsDone = !item.IsDone);
            }
        }

        public ObservableCollection<TodoItem> Todos { get; set; }

        public TasksViewModel()
        {
            this.Todos = new ObservableCollection<TodoItem>
            {
                new TodoItem { Title = "Feed the cats" },
                new TodoItem { Title = "Wash the car", IsDone = true }
            };
        }
    }
}
    