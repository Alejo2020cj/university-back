using AutoMapper;
using System;
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
    public class CourseInstructorController : ApiController
    {

        private IMapper mapper;
        private readonly CourseInstructorService courseInstructorService = new CourseInstructorService(new CourseInstructorRepository(UniversityContext.Create()));

        public CourseInstructorController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var courseInstructor = await courseInstructorService.GetAll();
            var courseInstructorDTO = courseInstructor.Select(x => mapper.Map<CourseInstructorDTO>(x));

            return Ok(courseInstructorDTO); // Status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var courseInstructor = await courseInstructorService.GetById(id);
            var courseInstructorDTO = mapper.Map<CourseInstructorDTO>(courseInstructor);

            return Ok(courseInstructorDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseInstructorDTO courseInstructorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            //var course = new CourseDTO
            //{
            //    CourseId = courseDTO.CourseId,
            //    Title = courseDTO.Title,
            //    Credits = courseDTO.Credits
            //};

            //Ctrl + K + S Redondear el codigo
            try
            {
                var courseInstructor = mapper.Map<CourseInstructor>(courseInstructorDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                courseInstructor = await courseInstructorService.Insert(courseInstructor);
                return Ok(courseInstructorDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseInstructorDTO courseInstructorDTO, int id) // object - cuerpo pero si es prmitivo por la url 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (courseInstructorDTO.InstructorID != id)
                return BadRequest();

            var flag = await courseInstructorService.GetById(id);

            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                var courseInstructor = mapper.Map<CourseInstructor>(courseInstructorDTO);
                courseInstructor = await courseInstructorService.Insert(courseInstructor);
                return Ok(courseInstructor); //Sastus code 200
                //return Ok(courseDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }



        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await courseInstructorService.GetById(id);

            if (flag == null)
                return NotFound(); //status code 404

            try
            {
                if (!await courseInstructorService.DeleteCheckOnEntity(id))
                    await courseInstructorService.Delete(id);
                else
                    throw new Exception("ForeinKeys");
                return Ok();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);//status code 500
            }
        }
    }
}





