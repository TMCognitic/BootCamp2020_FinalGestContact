using GAuthRepository = GestContact.MVC.Models.Global.Repositories.AuthRepository;
using GCustomer = GestContact.Models.Global.Entities.Customer;
using GContactRepository = GestContact.MVC.Models.Global.Repositories.ContactRepository;
using GContact = GestContact.Models.Global.Entities.Contact;
using GestContact.MVC.Models.Client.Entities;
using GestContact.MVC.Models.Client.Repositories;
using GestContact.Models.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using GestContact.API.Models.Client.Repositories;
using GestContact.MVC.Inftrastructure;

namespace GestContact.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<ISessionManager, SessionManager>();

            services.AddTransient(sp =>
            {
                HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:6001/") };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            });

            services.AddScoped<IAuthRepository<GCustomer>, GAuthRepository>();
            services.AddScoped<IAuthRepository<Customer>, AuthRepository>();
            services.AddScoped<IContactRepository<GContact>, GContactRepository>();
            services.AddScoped<IContactRepository<Contact>, ContactRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
