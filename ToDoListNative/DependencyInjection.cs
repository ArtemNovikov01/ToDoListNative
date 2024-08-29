using ToDoListNative.Web.Settings;
using ToDoListNative.Domain;
using ToDoListNative.Application;

namespace ToDoListNative.Web
{
    public static class DependencyInjections
    {
        public static WebApplicationBuilder BuildWebApplication(this WebApplicationBuilder builder)
        {
            var webAppSettings = builder.Configuration.Get<WebAppSettings>()
                                 ?? throw new NullReferenceException("Не заданы настройки приложения");

            // Services
            builder.Services
                .AddApplication()
                .AddDatabase(webAppSettings.Database)
                .AddControllers();

            // Swagger
            builder.Services
                .AddSwaggerGen();

            return builder;
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("v1/swagger.json", "ToDo Test"); });

            app.UseRouting();

            app.MapControllers();

            app.Map("/", async context => {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("wwwroot/home-page.html");
            });

            return app;
        }
    }
}
