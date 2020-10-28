using System;
using System.ComponentModel.DataAnnotations;
namespace University.BL.DTOs
{
    public  class DepartmentDTO
    {

      
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "The field Title  is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Credits is required")]
        public decimal Budget { get; set; }


        [Required(ErrorMessage = "The field Credits is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field Credits is required")]
        public int InstructorID { get; set; }

        public InstructorDTO Instructor { get; set; }
    }
}
