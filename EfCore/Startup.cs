using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace EfCore
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
            // exemplo de connection string "Data Source=mydb.db"
            services.AddDbContext<LibraryContext>(
                opt => opt.UseSqlite(Configuration.GetConnectionString("SqliteConn")));
            // exemplo de connection string "Database=db_Talentos;DataSource=localhost;UserId=root;Password=" 
            //services.AddDbContext<LibraryContext>(
            //    opt => opt.UseMySQL(Configuration.GetConnectionString("MysqlConn")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Shayne Boyer", Email = "", Url = "https://twitter.com/spboyer" },
                    License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });
            });

            services.AddRouting();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            ctx.Database.EnsureCreated();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }
    }
}
