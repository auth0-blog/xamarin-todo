using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Todo.Models;
using Newtonsoft.Json;
using System.Linq;

namespace Todo.Repositories
{
    /// <summary>
    /// A data repository that marshals Todo items between the app and the API
    /// </summary>
    public class TodoDataRepository
    {
        const string API_BASE_URL = "http://localhost:3001/api/todo";

        /// <summary>
        /// Loads data from an external API
        /// </summary>
        public async Task<List<TodoItem>> LoadData()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(API_BASE_URL);

            var models = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return models.OrderBy(i => i.IsDone).ToList();
        }

        /// <summary>
        /// Creates a new todo item on the server
        /// </summary>
        public async Task AddItem(string title)
        {
            var client = new HttpClient();
            var model = new TodoItem { Title = title };
            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

            await client.PostAsync(API_BASE_URL, content);
        }

        /// <summary>
        /// Updates a todo item on the server
        /// </summary>
        /// <param name="item">The item that is to be updated.</param>
        public async Task UpdateItem(TodoItem item)
        {
            var client = new HttpClient();
            var url = $"{API_BASE_URL}/{item.Id}";
            var content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");

            await client.PutAsync(url, content);
        }

        /// <summary>
        /// Deletes an item on the server
        /// </summary>
        public async Task DeleteItem(TodoItem item)
        {
            var client = new HttpClient();
            var url = $"{API_BASE_URL}/{item.Id}";

            await client.DeleteAsync(url);
        }
    }
}
