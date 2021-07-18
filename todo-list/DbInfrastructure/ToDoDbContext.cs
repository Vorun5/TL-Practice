using Microsoft.EntityFrameworkCore;

namespace todo_list.DbInfrastructure
{
    public class ToDoDbContext : DbContext, IUnitOfWork
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        { }

        public void Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoEntityConfiguration());
        }
    }
}
