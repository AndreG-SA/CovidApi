using Covid.Configuration;
using Covid.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Covid.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void LoadConfiguration<TConfiguration>(IServiceCollection services) where TConfiguration : class, new()
        {
            TConfiguration configuration = new TConfiguration();
            Configuration.Bind(typeof(TConfiguration).Name, configuration);
            services.AddSingleton(configuration);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            LoadConfiguration<RapidApiConfiguration>(services);
            services.AddControllers().AddNewtonsoftJson();

            services.AddSingleton<ISecuredServiceClient, RapidServiceClient>();
            services.AddTransient<IDataInfrastructureService, DataInfrastructureService>();


            ConfigureSwagger(services);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Covid Response API");
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Covid Response API",
                    Description = "Covid Response API"
                });
            });
        }
    }
}
