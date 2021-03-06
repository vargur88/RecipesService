using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using RecipesService.Handlers.GetRecipes;
using RecipesService.Repository.Interfaces;
using RecipesService.Repository.InMemoryRepository;
using FluentValidation.AspNetCore;
using RecipesService.Handlers.Recipes.GetRecipes;
using RecipesService.Application.Extensions;

namespace RecipesService.Application
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddApiExplorer();

            services.AddSingleton<IRecipesRepository, RecipesInMemoryRepository>();
            services.AddSingleton<ICategoriesRepository, CategoriesInMemoryRepository>();

            services.AddFluentValidation(t => t.RegisterValidatorsFromAssemblyContaining<GetRecipesRequestValidator>());
            services.AddMediatR(typeof(GetRecipesHandler).Assembly);

            services.AddSwaggerGen(t => t.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v1" }));
            services.AddSwaggerGenNewtonsoftSupport();

            services.InitData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
