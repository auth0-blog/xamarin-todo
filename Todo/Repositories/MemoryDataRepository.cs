using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Todo.Models;
using Xamarin.Forms;
using System.Linq;

namespace Todo.Repositories
{
    /// <summary>
    /// A data repository that marshals Todo items between the app and the API
    /// </summary>
    public class MemoryDataRepository : IDataRepository
    {
        private List<TodoItem> items;
        private int nextId;

        public MemoryDataRepository()
        {
            items = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Finish building that cat GIF app" },
                new TodoItem { Id = 2, Title = "Wash the car" },
                new TodoItem { Id = 3, Title = "Lunch meeting with colleagues", IsDone = true }
            };

            SetNextId();
        }

        /// <summary>
        /// Gets the Todo item data
        /// </summary>
        public Task<IEnumerable<TodoItem>> GetData()
        {
            return Task.FromResult(items.Select(i => i.Clone() as TodoItem));
        }

        /// <summary>
        /// Removes the specified item from the data set
        /// </summary>        
        public Task<IEnumerable<TodoItem>> RemoveItem(TodoItem item)
        {
            items.Remove(item);
            return GetData();
        }

        /// <summary>
        /// Adds a new item to the collection
        /// </summary>
        /// <param name="item">The item to add</param>        
        public Task<IEnumerable<TodoItem>> AddItem(TodoItem item)
        {
            items.Add(item);
            SetNextId();

            return GetData();
        }

        /// <summary>
        /// Updates the item in the list
        /// </summary>
        public Task<IEnumerable<TodoItem>> UpdateItem(TodoItem item)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.IsDone = item.IsDone;
            }

            return GetData();
        }

        /// <summary>
        /// Figures out what the next item ID should be
        /// </summary>
        private void SetNextId()
        {
            nextId = items.Max(i => i.Id) + 1;
        }
    }
}
