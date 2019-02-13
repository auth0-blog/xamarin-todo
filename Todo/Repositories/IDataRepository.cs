using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Repositories
{
    public interface IDataRepository
    {
        Task<IEnumerable<TodoItem>> AddItem(TodoItem item);
        Task<IEnumerable<TodoItem>> GetData();
        Task<IEnumerable<TodoItem>> RemoveItem(TodoItem item);
        Task<IEnumerable<TodoItem>> UpdateItem(TodoItem item);
    }
}