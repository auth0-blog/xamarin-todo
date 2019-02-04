using System;
using System.ComponentModel;

namespace Todo.Models
{
    public class TodoItem : ObservableModel
    {
        bool isDone = false;

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone
        {
            get { return this.isDone; }
            set
            {
                this.isDone = value;
                NotifyPropertyChanged("IsDone");
            }
        }

    }
}
