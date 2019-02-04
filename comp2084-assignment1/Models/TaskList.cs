namespace comp2084_assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskList")]
    public partial class TaskList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskList()
        {
            SubTasks = new HashSet<SubTask>();
        }

        [Key]
        public int TaskID { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskName { get; set; }

        public bool TaskStatus { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubTask> SubTasks { get; set; }
    }
}
