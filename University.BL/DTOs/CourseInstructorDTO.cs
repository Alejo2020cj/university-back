using System;
using System.ComponentModel.DataAnnotations;
using University.BL.Models;

namespace University.BL.DTOs
{
   public class CourseInstructorDTO
    {

        [Required(ErrorMessage = "The field course ID is required")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The field Title  is required")]
        [StringLength(50)]
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "The field Credits is required")]
        public int Course { get; set; }


        [Required(ErrorMessage = "The field Credits is required")]
        public int Instructor { get; set; }

    }
}
