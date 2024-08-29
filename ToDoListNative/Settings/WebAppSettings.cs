using ToDoListNative.Domain.Settings;

namespace ToDoListNative.Web.Settings;

/// <summary>
/// Настройки приложения
/// </summary>
public sealed record WebAppSettings
{
    /// <summary>
    /// Настройки БД
    /// </summary>
    public DatabaseSettings? Database { get; init; }
}
