using auvo.Application.Interface;
using auvo.Application.Services;
using DevelopersChallenge.src.auvo.Domain.Interfaces.IRepositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DevelopersChallenge.src.auvo.Persistence.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace api_auvo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AuvoContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            services.AddControllers();

            services.AddCors();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api_auvo", Version = "v1" });
            });

            services.AddCors();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
                  options.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api_auvo v1"));
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