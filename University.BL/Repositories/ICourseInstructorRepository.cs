using University.BL.Models;
using System.Threading.Tasks;


namespace University.BL.Repositories
{
    public interface ICourseInstructorRepository : IGenericRepository<CourseInstructor>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}

