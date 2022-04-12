using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TopicTwisterService.Player.Domain;

namespace TopicTwisterService
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
            services.AddDbContextPool<DataContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                                  sqlServerOptionsAction: sqlOptions =>{sqlOptions.EnableRetryOnFailure();}
                                  ).EnableSensitiveDataLogging()
            );
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddControllers();
            services.AddControllers().AddJsonOptions(o => {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRoundRepository,RoundRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IWordsEnteredByPlayerRepository, WordsEnteredByPlayerRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TopicTwisterService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TopicTwisterService v1"));
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
