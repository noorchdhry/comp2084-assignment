namespace comp2084_assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<SubTask> SubTasks { get; set; }
        public virtual DbSet<TaskList> TaskLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubTask>()
                .Property(e => e.SubName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskList>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskList>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TaskList>()
                .HasMany(e => e.SubTasks)
                .WithRequired(e => e.TaskList)
                .WillCascadeOnDelete(false);
        }
    }
}
