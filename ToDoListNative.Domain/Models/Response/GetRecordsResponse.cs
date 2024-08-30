namespace ToDoListNative.Domain.Models.Response
{
    public class GetRecordsResponse
    {
        public IList<RecordDto> Records { get; set; } = null!;
        public int TotalCount { get; set; }
    }

    public class RecordDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Title { get; set; } = null!;
        public bool Status { get; set; }
    }
}
