namespace ToDoListNative.Domain.Models.Request;
public class ChangeStatusRecordRequest
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
