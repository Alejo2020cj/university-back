using System;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class CourseInstructorService : GenericService<CourseInstructor>, ICourseInstructorService
    {
        private readonly ICourseInstructorRepository CourseInstructorRepository;
        public CourseInstructorService(ICourseInstructorRepository courseInstructorRepository) : base(courseInstructorRepository)
        {
            this.CourseInstructorRepository = courseInstructorRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            //throw new NotImplementedException();
            return await CourseInstructorRepository.DeleteCheckOnEntity(id);
        }
    }
}

