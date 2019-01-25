using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.Repositories
{
    public class TodoDataRepository
    {
        public ObservableCollection<TodoItem> Items { get; set; }

        public TodoDataRepository()
        {
            this.Items = new ObservableCollection<TodoItem>
            {
                new TodoItem { Title = "Feed the cats" },
                new TodoItem { Title = "Wash the car", IsDone = true }
            };
        }
    }
}
