using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiProject.Models;
using WebApiProject.Repository;
using WebApiProject.Service;

namespace WebApiProject
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
            services.AddSwaggerGen();
            services.AddDbContextPool<ItemsStoreContext>(options=>options.UseSqlServer(Configuration["ConnectionString:ItemsDB"]));
            services.AddScoped<IRepository<Item>,ItemRepository>();
            services.AddScoped<IRepository<Category>,CategoryRepository>();
            services.AddScoped<IRepository<SubCategory>,SubCategoryRepository>();
            services.AddScoped<IService,ItemService>();
            services.AddControllers();           
         }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Item API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
