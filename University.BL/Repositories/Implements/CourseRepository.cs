using University.BL.Data;
using University.BL.Models;
using System.Threading.Tasks;
using System.Data.Entity;


namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly UniversityContext universityContext;
        public CourseRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;

        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            //throw new System.NotImplementedException();
            var flag = await universityContext.Enrollments.AnyAsync
                (x => x.CourseID == id);
            return flag;


        }
    }
}
