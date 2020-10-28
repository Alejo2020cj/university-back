using University.BL.Models;
using University.BL.Repositories;
using University.BL.Services.Implements;

namespace University.BL.Services.Implements
{
    public class OfficeAssignmentService : GenericService<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentService(IOfficeAssignmentRepository officeAssignmentRepository) : base(officeAssignmentRepository)
        { 
        }
    }
}

