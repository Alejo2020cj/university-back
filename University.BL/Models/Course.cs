using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.BL.Models
{
    [Table("Course", Schema = "dbo")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int CourseID { get; set; }
        [StringLength(50)]
        public String Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments {get; set;}
}
}

