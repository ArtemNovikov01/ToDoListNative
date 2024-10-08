﻿using Microsoft.EntityFrameworkCore;
using ToDoListNative.Application.Mappers;
using ToDoListNative.Application.Validators;
using ToDoListNative.Domain.Context;
using ToDoListNative.Domain.CoresInterfaces;
using ToDoListNative.Domain.Models.Request;
using ToDoListNative.Domain.Models.Response;
using ToDoListNative.Application.Extensions;
using static ToDoListNative.Application.Extensions.RecordExtensions;
using ToDoListNative.Domain.Models.Entities;
using System.Collections.Generic;

namespace ToDoListNative.Application.Cores;
public class RecordCore : IRecordCors
{
    private readonly RecordContext _recordContext;
    public RecordCore(RecordContext recordContext)
    {
        _recordContext = recordContext;
    }

    public async Task StatusChangeRecord(ChangeStatusRecordRequest request)
    {
        RecordValidator.IdValidator(request.Id);

        var record = await _recordContext.Records.FirstOrDefaultAsync(r => r.Id == request.Id);
        RecordValidator.CheckValueValidator(record, request.Id);

        record!.ChangeStatus(request.Status);

        await _recordContext.SaveChangesAsync();
    }

    public async Task<GetRecordInfoResponse> CreateRecord(CreateRecordRequest request)
    {
        RecordValidator.CreateRecordValidator(request);

        var lastNumber = _recordContext.Records.Count() <= 0 ? 1 : await Task.Run(() => _recordContext.Records.Max(x => x.Number) + 1);

        var record = RecordMapper.CreateRecordMapper(request, lastNumber);
        record = _recordContext.Records.Add(record).Entity;
        await _recordContext.SaveChangesAsync();

        return RecordMapper.GetRecordInfoMapper(record!);
    }

    public async Task DeleteRecord(int id)
    {
        RecordValidator.IdValidator(id);

        var record = await _recordContext.Records.FirstOrDefaultAsync(r => r.Id == id);
        RecordValidator.CheckValueValidator(record, id);

        _recordContext.Records.Remove(record!);
        await _recordContext.SaveChangesAsync();
    }

    public async Task<GetRecordInfoResponse> GetRecord(int id)
    {
        RecordValidator.IdValidator(id);

        var record = await _recordContext.Records.FirstOrDefaultAsync(r => r.Id == id);
        RecordValidator.CheckValueValidator(record, id);

        return RecordMapper.GetRecordInfoMapper(record!);
    }

    public GetRecordsResponse GetRecords(FilterRecordsRequest request)
    {
        RecordValidator.FilterRecordValidator(request);

        var query = _recordContext.Records.AsQueryable();

        var recordsQuery = query
            .SearchRecord(request.Search)
            .FilterIsComplete(request.IsComplete);

        var totalCount = recordsQuery.Count();

        var records = recordsQuery
            .OrderBy(r => r.Id)
            .Skip(request.Skip)
            .Take(request.Count)
            .Select(r => 
                new RecordDto()
                {
                    Id = r.Id,
                    Number = r.Number.ToString(),
                    Title = r.Title,
                    Status = r.IsComplete
                })
                .ToList();

        return new GetRecordsResponse
        {
            Records = records,
            TotalCount = totalCount
        };
    }

    public async Task<GetRecordInfoResponse> UpdateRecord(UpdateRecordRequest request)
    {
        RecordValidator.IdValidator(request.Id);

        var record = await _recordContext.Records.FirstOrDefaultAsync(r => r.Id == request.Id);
        RecordValidator.CheckValueValidator(record, request.Id);

        RecordMapper.UpdateRecordMapper(record!, request);

        await _recordContext.SaveChangesAsync();

        return RecordMapper.GetRecordInfoMapper(record!);
    }
}
