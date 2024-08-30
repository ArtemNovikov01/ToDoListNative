using ToDoListNative.Domain.Models.Entities;
using ToDoListNative.Domain.Models.Request;
using ToDoListNative.Domain.Models.Response;

namespace ToDoListNative.Application.Mappers;
public static class RecordMapper
{
    public static GetRecordInfoResponse GetRecordInfoMapper(Record record)
    {
        return new GetRecordInfoResponse
        {
            Id = record.Id,
            Number = record.Number.ToString(),
            Title = record.Title,
            Content = record.Content,
            isComplete = record.IsComplete
        };
    }

    public static Record CreateRecordMapper(CreateRecordRequest request, int number)
    {
        return new Record(number, request.Title,request.Content);
    }

    public static Record UpdateRecordMapper(Record record, UpdateRecordRequest request)
    {
        record.UpdateRecord(request.Title, request.Content);

        return record;
    }

}
