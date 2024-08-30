namespace ToDoListNative.Domain.Models.Request
{
    public class FilterRecordsRequest
    {
        public string? Search { get; set; }
        public int Skip { get; set; }
        public int Count { get; set; }
        public bool? IsComplete { get; set; }
    }
}
