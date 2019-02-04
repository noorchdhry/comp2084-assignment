namespace COMP2084_Local_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubTask")]
    public partial class SubTask
    {
        [Key]
        public int SubID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubName { get; set; }

        public bool SubStatus { get; set; }

        public int TaskID { get; set; }

        public virtual Task Task { get; set; }
    }
}
