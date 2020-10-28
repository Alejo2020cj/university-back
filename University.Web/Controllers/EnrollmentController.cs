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
    public class EnrollmentController : ApiController
    {
        private IMapper mapper;
        private readonly EnrollmentService enrollmentService = new EnrollmentService(new EnrollmentRepository(UniversityContext.Create()));

        public EnrollmentController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var enrollment = await enrollmentService.GetAll();
            var enrollmentDTO = enrollment.Select(x => mapper.Map<EnrollmentDTO>(x));

            return Ok(enrollmentDTO); // Status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var enrollment = await enrollmentService.GetById(id);
            var enrollmentDTO = mapper.Map<EnrollmentDTO>(enrollment);

            return Ok(enrollmentDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(EnrollmentDTO enrollmentDTO)
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
                var enrollment = mapper.Map<Enrollment>(enrollmentDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                enrollment = await enrollmentService.Insert(enrollment);
                return Ok(enrollmentDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(EnrollmentDTO enrollmentDTO, int id) // object - cuerpo pero si es prmitivo por la url 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (enrollmentDTO.EnrollmentID != id)
                return BadRequest();

            var flag = await enrollmentService.GetById(id);

            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                var enrollment = mapper.Map<Enrollment>(enrollmentDTO);
                enrollment = await enrollmentService.Insert(enrollment);
                return Ok(enrollment); //Sastus code 200
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
            var flag = await enrollmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                await enrollmentService.Delete(id);
                //else
                // throw new Exception("ForengKeys");

                return Ok(); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }
    }
}
