using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;
using System.Data.Entity;

namespace University.BL.Repositories.Implements
{
    public class CourseInstructorRepository : GenericRepository<CourseInstructor>, ICourseInstructorRepository
    {
        private readonly UniversityContext universityContext;
        public CourseInstructorRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.Courses.AnyAsync
    (x => x.CourseID == id);
            return flag;



        }

    }
}

     //ojo crear relación entre instructor