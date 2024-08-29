using Microsoft.Extensions.DependencyInjection;
using ToDoListNative.Application.Cores;
using ToDoListNative.Domain.CoresInterfaces;

namespace ToDoListNative.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddTransient<IRecordCors, RecordCore>();
    }
}
