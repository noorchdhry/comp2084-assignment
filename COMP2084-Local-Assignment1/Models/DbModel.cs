namespace COMP2084_Local_Assignment1.Models
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
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubTask>()
                .Property(e => e.SubName)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskDetail)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.SubTasks)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasOptional(e => e.Task1)
                .WithRequired(e => e.Task2);
        }
    }
}
