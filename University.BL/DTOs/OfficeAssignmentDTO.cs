using System.ComponentModel.DataAnnotations;


namespace University.BL.DTOs
{
   public class OfficeAssignmentDTO
    {

        [Required(ErrorMessage = "The field Title  is required")]
        [StringLength(50)]
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "The field Credits is required")]
        public string Location { get; set; }
    }
}
