namespace ToDoListNative.Domain.Models.Request
{
    public class CreateRecordRequest
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
