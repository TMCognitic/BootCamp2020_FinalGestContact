﻿using GestContact.MVC.Models.Global.Entities;
using GestContact.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GestContact.Models.Forms;

namespace GestContact.MVC.Models.Global.Repositories
{
    public class AuthRepository : IAuthRepository<Customer>
    {
        private readonly HttpClient _client;

        public AuthRepository(HttpClient client)
        {
            _client = client;
        }

        public Customer Login(string email, string passwd)
        {
            using (_client)
            {
                string contentJson = JsonSerializer.Serialize(new { email, passwd });
                HttpContent httpContent = new StringContent(contentJson);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = _client.PostAsync("api/auth/login", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<Customer>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public void Register(Customer entity)
        {
            using (_client)
            {
                RegisterForm form = new RegisterForm() { LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Passwd = entity.Passwd, Passwd2 = entity.Passwd };
                string contentJson = JsonSerializer.Serialize(form);
                HttpContent httpContent = new StringContent(contentJson);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = _client.PostAsync("api/auth/register", httpContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }
    }
}
