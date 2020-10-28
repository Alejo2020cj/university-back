using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }

        [ForeignKey("Course")]
        public String LastName { get; set; }

        [ForeignKey("Instructor")]
        public String FirstMidName { get; set; }

        [ForeignKey("Instructor")]
        public DateTime HireDate { get; set; }


    }
}
