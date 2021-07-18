using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo_list.Entities;

namespace todo_list.DbInfrastructure
{
    public class ToDoEntityConfiguration : IEntityTypeConfiguration<ToDoEntity>
    {
        public void Configure(EntityTypeBuilder<ToDoEntity> builder)
        {
            builder.ToTable("ToDoList")
                .HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("ToDoId");
        }
    }
}
