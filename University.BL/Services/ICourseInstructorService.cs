using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services
{
    public interface ICourseInstructorService : IGenericService<CourseInstructor>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}