using System.Data.Entity;
using University.BL.Models;


namespace University.BL.Data
{
    public class UniversityContext :DbContext
    {
        public UniversityContext() : base ("UniversityContext")
        { 
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }



        public static UniversityContext Create()
        {

            return new UniversityContext();
        }

    }
}


//atajos control + k + d acomoda las llaves formatear
//ctrl + k + c comentamos un bloque
//ctrl + k + u descomentamos
//ctrl + k + s rodeamos el codigo
//prop + doble tap  me crea los get y set
//ctrl + d mepongo al frente al final de la linea y aplico para  duplicarla
//for doble tap con esto creo el ford completo
//ctror + doble tap nos crea el metodo contructor