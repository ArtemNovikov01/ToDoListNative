using Microsoft.EntityFrameworkCore;
using ToDoListNative.Domain.Models.Entities;

namespace ToDoListNative.Domain.Context
{
    public class RecordContext : DbContext
    {
        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Record> Records { get; set; }
    }
}
