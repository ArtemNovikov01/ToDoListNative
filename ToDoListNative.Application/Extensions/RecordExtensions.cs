using ToDoListNative.Domain.Models.Entities;

namespace ToDoListNative.Application.Extensions;
public static class RecordExtensions
{
    public static IQueryable<Record> SearchRecord(IQueryable<Record> query, string? search)
    {
        var trimmedSearch = search?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(trimmedSearch))
        {
            return query;
        }

        return query.Where(r => r.Title == search || r.Content == search);
    }
}
