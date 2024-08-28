namespace ToDoListNative.Domain.Models.Response
{
    public class GetRecordResponse
    {
        public IList<RecordDto> Records { get; set; } = null!;
        public int TotalCount { get; set; }
    }

    public class RecordDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
