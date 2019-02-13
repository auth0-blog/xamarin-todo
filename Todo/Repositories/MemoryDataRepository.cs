using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.Repositories
{
    /// <summary>
    /// A data repository that marshals Todo items between the app and the API
    /// </summary>
    public class MemoryDataRepository : IDataRepository
    {
        private List<TodoItem> items;

        public MemoryDataRepository()
        {
            items = new List<TodoItem>
            {
                new TodoItem { Title = "Finish building that cat GIF app" },
                new TodoItem { Title = "Wash the car" },
                new TodoItem { Title = "Lunch meeting with colleagues", IsDone = true }
            };
        }

        /// <summary>
        /// Gets the Todo item data
        /// </summary>
        public Task<List<TodoItem>> GetData()
        {
            return Task.FromResult(items);
        }

        /// <summary>
        /// Removes the specified item from the data set
        /// </summary>        
        public Task<List<TodoItem>> RemoveItem(TodoItem item)
        {
            items.Remove(item);

            return Task.FromResult(items);
        }

        /// <summary>
        /// Adds a new item to the collection
        /// </summary>
        /// <param name="item">The item to add</param>        
        public Task<List<TodoItem>> AddItem(TodoItem item)
        {
            items.Add(item);
            return Task.FromResult(items);
        }
    }
}
