namespace ToDoListNative.Domain.Models.Entities
{
    public class Record
    {
        public int Id { get; private set; }

        /// <summary>
        ///     Порядковый номер
        /// </summary>
        public int Number { get; private set; }

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

        public Record(int number, string title, string content) {
            Number = number;
            Title = title;
            Content = content;
            IsComplete = false;
        }

        public void UpdateRecord(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public void ChangeStatus(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }
}
