using ToDoListNative.Domain.Models.Enums;

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
        public Status Status { get; private set; }

        public Record() { }

        //public Record() {
        //    Status = 0;
        //}
    }
}
