using GAuthRepository = GestContact.API.Models.Global.Repositories.AuthRepository;
using GCustomer = GestContact.API.Models.Global.Entities.Customer;
using GContactRepository = GestContact.API.Models.Global.Repositories.ContactRepository;
using GContact = GestContact.API.Models.Global.Entities.Contact;
using GestContact.API.Models.Client.Entities;
using GestContact.API.Models.Client.Repositories;
using GestContact.API.Infrastructure.Security;
using GestContact.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using Tools.Connections.Database;


namespace GestContact.API
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
            services.AddControllers()
                    .AddXmlDataContractSerializerFormatters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestContact.API", Version = "v1" });
            });

            services.AddSingleton<IConnection>(sp => new Connection(SqlClientFactory.Instance, @"Data Source=VM-COREWIN\SQL2014DEV;Initial Catalog=GestContact;Integrated Security=True;"));
            services.AddSingleton<IAuthRepository<GCustomer>, GAuthRepository>();
            services.AddSingleton<IAuthRepository<Customer>, AuthRepository>();
            services.AddSingleton<IContactRepository<GContact>, GContactRepository>();
            services.AddSingleton<IContactRepository<Contact>, ContactRepository>();
            services.AddSingleton<ITokenService, TokenService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestContact.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
