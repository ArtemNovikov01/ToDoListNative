namespace ToDoListNative.Domain.Models.Request
{
    public class UpdateRecordRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool isComplete { get; set; }
    }
}
