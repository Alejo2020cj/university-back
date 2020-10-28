using AutoMapper;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>(); // GET
                cfg.CreateMap<CourseDTO, Course>(); // POST - PUT

                cfg.CreateMap<CourseInstructor, CourseInstructorDTO>(); // POST - PUT
                cfg.CreateMap<CourseInstructorDTO, CourseInstructor>(); // POST - PUT

                cfg.CreateMap<Department, DepartmentDTO>(); // POST - PUT
                cfg.CreateMap<DepartmentDTO, Department>(); // POST - PUT

                cfg.CreateMap<Enrollment, EnrollmentDTO>(); // POST - PUT
                cfg.CreateMap<EnrollmentDTO, Enrollment>(); // POST - PUT

                cfg.CreateMap<Instructor, InstructorDTO>(); // POST - PUT
                cfg.CreateMap<InstructorDTO, Instructor>(); // POST - PUT

                cfg.CreateMap<OfficeAssignment, OfficeAssignmentDTO>(); // POST - PUT
                cfg.CreateMap<OfficeAssignmentDTO, OfficeAssignment>(); // POST - PUT

                cfg.CreateMap<Student, StudentDTO>(); // POST - PUT
                cfg.CreateMap<StudentDTO, Student>(); // POST - PUT
            });
        }
    }
}
