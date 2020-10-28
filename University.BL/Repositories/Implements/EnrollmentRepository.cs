using University.BL.Data;
using University.BL.Models;
using University.BL.Repositories.Implements;

namespace University.BL.Repositories.Implements
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(UniversityContext universityContext) : base(universityContext)
        {

        }
    }
}
