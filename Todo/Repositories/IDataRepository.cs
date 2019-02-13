using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Repositories
{
    public interface IDataRepository
    {
        Task<List<TodoItem>> AddItem(TodoItem item);
        Task<List<TodoItem>> GetData();
        Task<List<TodoItem>> RemoveItem(TodoItem item);
    }
}