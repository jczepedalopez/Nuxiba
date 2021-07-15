using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Nuxiba_testdevjr_1.Models;
using System.Linq;
using System.Text;

namespace Nuxiba_testdevjr_1
{
    public class RestService
    {
        HttpClient _client;
        string _url = "https://jsonplaceholder.typicode.com";

        public RestService()
        {
            _client = new HttpClient();            
        }       

        internal async Task <List<Todos>> GetAllTodosByUserAsync(Users user)
        {
            string url = $"{this._url}/users/{user.Id}/todos";
            List<Todos> todos = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    todos = JsonConvert.DeserializeObject<List<Todos>>(content);
                    todos.OrderByDescending(x => x.Id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return todos;
        }

        internal async Task<List<Comments>> GetAllCommentsByPostAsync(Posts post)
        {
            string url = $"{this._url}/post/{post.Id}/comments";
            List<Comments> comments = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    comments = JsonConvert.DeserializeObject<List<Comments>>(content);
                    comments.OrderByDescending(x => x.Id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return comments;
        }


        internal async Task<List<Posts>> GetAllPostsByUserAsync(Users user)
        {
            string url = $"{this._url}/users/{user.Id}/posts";
            List<Posts> posts = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonConvert.DeserializeObject<List<Posts>>(content);
                    foreach (var post in posts)
                    {
                        post.Comments = await GetAllCommentsByPostAsync(post);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return posts;
        }

        internal async Task<string> PutTodo(Todos todo)
        {
            var result = "000";
            string url = $"{this._url}/users/{todo.UserId}/todos";
            try
            {
                var request = JsonConvert.SerializeObject(todo);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var resultData = await response.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Todos>(resultData);
                    result = todo.Id;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return result;
        }

        internal async Task<List<Users>> GetAllUsersAsync()
        {
            string url = $"{this._url}/users";
            List<Users> users = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<Users>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return users;
        }        
    }
}
