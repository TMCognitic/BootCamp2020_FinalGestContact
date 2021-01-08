using GestContact.Models.Global.Entities;
using GestContact.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GestContact.MVC.Models.Global.Repositories
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private readonly HttpClient _client;

        public ContactRepository(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<Contact> Get(int customerId)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/contact/{customerId}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<Contact[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public Contact Get(int customerId, int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync($"api/contact/{customerId}/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<Contact>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public void Insert(Contact entity)
        {
            using (_client)
            {
                string contentJson = JsonSerializer.Serialize(entity);
                HttpContent httpContent = new StringContent(contentJson);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = _client.PostAsync($"api/contact/{entity.CustomerId}", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        public void Update(int id, Contact entity)
        {
            using (_client)
            {
                string contentJson = JsonSerializer.Serialize(entity);
                HttpContent httpContent = new StringContent(contentJson);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = _client.PutAsync($"api/contact/{entity.CustomerId}/{id}", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        public void Delete(int customerId, int id)
        {
            using (_client)
            {
                HttpResponseMessage httpResponseMessage = _client.DeleteAsync($"api/contact/{customerId}/{id}").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }
    }
}
