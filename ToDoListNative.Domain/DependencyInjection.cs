using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoListNative.Domain.Context;
using ToDoListNative.Domain.Settings;

namespace ToDoListNative.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, DatabaseSettings? databaseSettings)
        {
            if (databaseSettings?.ConnectionString is null)
            {
                throw new ArgumentNullException(nameof(databaseSettings), "Не заданы настройки БД");
            }

            services.AddDbContext<RecordContext>(opt => opt.UseNpgsql(databaseSettings.ConnectionString));

            return services;
        }
    }
}
