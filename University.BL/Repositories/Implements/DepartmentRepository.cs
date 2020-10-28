using University.BL.Data;
using University.BL.Models;


namespace University.BL.Repositories.Implements
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(UniversityContext universityContext) : base(universityContext)
        { 
        }
    }
}


