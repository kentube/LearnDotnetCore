using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpyStore.DAL.EF;
using SpyStore.DAL.Initializers;
using SpyStore.DAL.Repos;
using SpyStore.DAL.Repos.Interfaces;
using SpyStore.Service.Filters;

namespace SpyStore.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services
                .AddMvcCore(config => config.Filters.Add(new SpyStoreExceptionFilter(HostingEnvironment.IsDevelopment())))
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                })
                ;

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });

            string connectionString = Configuration.GetConnectionString("SpyStore");
            services.AddDbContext<StoreContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();

            // Build the intermediate service provider
            var serviceProvider = services.BuildServiceProvider();
            StoreDataInitializer.InitializeData(serviceProvider);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //using (var serviceScope = app.ApplicationServices
                //    .GetRequiredService<IServiceScopeFactory>()
                //    .CreateScope())
                //{
                //    var appService = app.ApplicationServices;
                //    var storeContext = appService.GetService<StoreContext>();

                //    StoreDataInitializer.InitializeData(app.ApplicationServices);
                //}
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
