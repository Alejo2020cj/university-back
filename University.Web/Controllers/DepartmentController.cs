using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;


namespace University.Web.Controllers
{
    public class DepartmentController : ApiController
    {



            private IMapper mapper;
            private readonly DepartmentService departmentService = new DepartmentService(new DepartmentRepository(UniversityContext.Create()));
            public DepartmentController()
            {
                this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();



            }
            //[HttpPost] //insertar - create
            // [HttpGet]  //Consultas - Read      
            // [HttpPut]  //Modificar - Update
            // [HttpDelete] //Eliminar - Delete

            [HttpGet]
            public async Task<IHttpActionResult> Get()
            {
                var Department = await departmentService.GetAll();
                var DepartmentDTO = Department.Select(x => mapper.Map<DepartmentDTO>(x));


                return Ok(DepartmentDTO);//status code 200
            }


            [HttpGet]
            public async Task<IHttpActionResult> Get(int id)
            {
                var Department = await departmentService.GetById(id);
                var DepartmentDTO = mapper.Map<DepartmentDTO>(Department);


                return Ok(DepartmentDTO);//status code 200
            }

            [HttpPost]

            public async Task<IHttpActionResult> Post(DepartmentDTO departmentDTO)
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                // status code 400
                //var course = new Course
                //{
                //    CourseID = CourseDTO.CourseID,
                //    Title = courseDTO.Title,
                //    Credits = courseDTO.Credits

                //};
                try
                {
                    var departament = mapper.Map<Department>(departmentDTO);

                    //var context = UniversityContext.Create();
                    //context.Courses.Add(course);
                    //await context.SaveChangesAsync();

                    departament = await departmentService.Insert(departament);
                    return Ok(departmentDTO);//status code 200
                }
                catch (System.Exception ex)
                {

                    return InternalServerError(ex);//status code 500
                }


            }





            [HttpPut]

            public async Task<IHttpActionResult> Put(DepartmentDTO departmentDTO, int id)//objet -> body / primitivo -> url
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                if (departmentDTO.DepartmentID != id)
                    return BadRequest();

                var flag = await departmentService.GetById(id);
                if (flag == null)
                    return NotFound(); //status code 404

                try
                {
                    var department = mapper.Map<Department>(departmentDTO);

                department = await departmentService.Update(department);
                    return Ok(department);//status code 200
                }
                catch (System.Exception ex)
                {

                    return InternalServerError(ex);//status code 500
                }


            }



            [HttpDelete]

            public async Task<IHttpActionResult> Delete(int id)
            {

                var flag = await departmentService.GetById(id);
                if (flag == null)
                    return NotFound(); //status code 404

                try
                {
                    await departmentService.Delete(id);
                    return Ok();

                }
                catch (System.Exception ex)
                {

                    return InternalServerError(ex);//status code 500
                }


            }
        }
    }

