using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.BL.Models;

namespace University.BL.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstMidName { get; set; }
      
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set;}


    }
}
