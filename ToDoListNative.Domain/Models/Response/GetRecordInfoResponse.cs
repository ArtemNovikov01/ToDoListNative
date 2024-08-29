namespace ToDoListNative.Domain.Models.Response
{
    public class GetRecordInfoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool isComplete { get; set; }
    }
}
