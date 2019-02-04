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
        const string API_URL = "http://localhost:3001/api/todo";

        /// <summary>
        /// Loads data from an external API
        /// </summary>
        public async Task<List<TodoItem>> LoadData()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(API_URL);

            var models = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return models.OrderBy(i => i.IsDone).ToList();
        }
    }
}
