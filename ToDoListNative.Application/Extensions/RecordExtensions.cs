using ToDoListNative.Domain.Models.Entities;

namespace ToDoListNative.Application.Extensions;
public static class RecordExtensions
{
    public static IQueryable<Record> SearchRecord(this IQueryable<Record> query, string? search)
    {
        var trimmedSearch = search?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(trimmedSearch))
        {
            return query;
        }

        return query.Where(r => r.Title.Contains(trimmedSearch!) || r.Number.ToString().Contains(trimmedSearch!));
    }

    public static IQueryable<Record> FilterIsComplete(this IQueryable<Record> query, bool? isComplete)
    {

        if (isComplete is null)
        {
            return query;
        }

        return query.Where(r => r.IsComplete == isComplete);
    }
}
