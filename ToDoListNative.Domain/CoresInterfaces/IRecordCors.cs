using ToDoListNative.Domain.Models.Request;
using ToDoListNative.Domain.Models.Response;

namespace ToDoListNative.Domain.CoresInterfaces
{
    public interface IRecordCors
    {
        public Task<GetRecordInfoResponse>  GetRecord(int id);
        public GetRecordsResponse GetRecords(FilterRecordsRequest request);
        public Task<GetRecordInfoResponse> CreateRecord(CreateRecordRequest request);
        public Task<GetRecordInfoResponse> UpdateRecord(UpdateRecordRequest request);
        public Task DeleteRecord(int id);
        public Task StatusChangeRecord(ChangeStatusRecordRequest request);
    }
}
