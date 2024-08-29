namespace ToDoListNative.Domain.Models.Entities
{
    public class Record
    {
        public int Id { get; private set; }

        /// <summary>
        ///     Заголовок
        /// </summary>
        public string Title { get; private set; } = null!;

        /// <summary>
        ///     Содержание
        /// </summary>
        public string Content { get; private set; } = null!;

        /// <summary>
        ///     Статус
        /// </summary>
        public bool IsComplete { get; private set; }

        public Record() { }

        public Record(string title, string content) {
            Title = title;
            Content = content;
            IsComplete = false;
        }

        public void UpdateRecord(string title, string content, bool isComplete)
        {
            Title = title;
            Content = content;
            IsComplete = isComplete;
        }

        public void ChangeStatus(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }
}
