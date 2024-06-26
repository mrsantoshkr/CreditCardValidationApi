﻿using CreditCardValidationApi.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CreditCardValidationApi", Version = "v1" });
        });
        services.AddScoped<ICreditCardService, CreditCardService>();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditCardValidationApi v1");
                c.RoutePrefix = string.Empty;  // This makes Swagger UI the root page
            });
        }

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Use(async (context, next) =>
        {
            logger.LogInformation("Handling request: " + context.Request.Path);
            await next.Invoke();
            logger.LogInformation("Finished handling request.");
        });
    }
}
