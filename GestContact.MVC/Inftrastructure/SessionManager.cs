using GestContact.MVC.Models.Client.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestContact.MVC.Inftrastructure
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public SessionCustomer Customer
        {
            get
            {
                if (!_session.Keys.Contains(nameof(Customer)))
                    return null;

                return JsonSerializer.Deserialize<SessionCustomer>(_session.GetString(nameof(Customer)));
            }

            set
            {
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(Customer), json);
            }
        }
    }
}
