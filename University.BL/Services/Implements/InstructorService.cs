using University.BL.Models;
using University.BL.Repositories.Implements;

namespace University.BL.Services.Implements
{
    public class InstructorService :GenericService<Instructor>, IInstructorService
    {

        public InstructorService(IInstructorRepository InstructorRepository) : base(InstructorRepository)
        { 
        
        }
    }
}



