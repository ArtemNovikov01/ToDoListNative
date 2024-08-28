
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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}

        public DbSet<Record> Records { get; set; }
    }
}
