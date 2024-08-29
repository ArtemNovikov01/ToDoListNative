using ToDoListNative.Application.Exceptions;
using ToDoListNative.Domain.Models.Entities;
using ToDoListNative.Domain.Models.Request;

namespace ToDoListNative.Application.Validators;
public static class RecordValidator
{
    public static void IdValidator(int id)
    {
        if (id <= 0) 
        {
            throw new BadRequestException("id должен быть больше 0");
        }
    }

    public static void CheckValueValidator(Record? record, int id)
    {
        if (record is null)
        {
            throw new NotFoundException($"Запись с id = {id}, не найдена");
        }
    }

    public static void CreateRecordValidator(CreateRecordRequest request)
    {
        if (string.IsNullOrEmpty(request.Title))
        {
            throw new BadRequestException("Поле 'Заголовок', должно быть заполнено");
        }

        if (string.IsNullOrEmpty(request.Content))
        {
            throw new BadRequestException("Поле 'Содержание', должно быть заполнено");
        }
    }

    public static void FilterRecordValidator(FilterRecordsRequest request)
    {
        if (request.Skip < 0)
        {
            throw new BadRequestException("Skip не может быть меньше 0");
        }

        if (request.Count <= 0)
        {
            throw new BadRequestException("Count должен быть больше 0");
        }
    }
}
