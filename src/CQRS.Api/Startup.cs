using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using CQRS.Api.Configurations;
using CQRS.Api.Security.AuthToken;
using CQRS.Api.Security.AuthToken.Jwt;
using CQRS.Api.Repositories.Admin;
using CQRS.Api.Repositories.Connections;
using CQRS.Api.Repositories.db;
using CQRS.Api.Behaviours.Behaviours;
using CQRS.Api.RequestModel.GetConnections;
using CQRS.Api.ResponseModel.GetConnections;

namespace CQRS.Api
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

            services.AddControllers();
            services.AddTransient<IUserAuthTokenBuilder, UserAuthTokenBuilder>();
            services.AddTransient<IJwtTokenHandler, HS256JwtTokenHandler>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IConnectionsRepository, ConnectionRepository>();
            services.AddTransient<IMongoDbClientConfigurations, MongoDbClientConfigurations>();

            services.AddTransient<IUserAuthTokenValidator, UserAuthTokenValidator>();           
            services.AddTransient(typeof(IPipelineBehavior<GetAllConnectionsRequestModel, GetAllConnectionsResponseModel>), typeof(ValidateAuthTokenBehavior<GetAllConnectionsRequestModel, GetAllConnectionsResponseModel>));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRS.Api", Version = "v1" });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());          
            
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
        }
      


            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.Api v1"));
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
