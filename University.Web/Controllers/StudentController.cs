using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using University.BL.DTOs;
using University.BL.Models;

namespace University.Web.Controllers
{
    public class StudentController : ApiController
    {
        private IMapper mapper;
        private readonly StudentService studentService = new StudentService(new StudentRepository(UniversityContext.Create()));

        public StudentController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var student = await studentService.GetAll();
            var studentDTO = student.Select(x => mapper.Map<StudentDTO>(x));

            return Ok(studentDTO); // Status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var student = await studentService.GetById(id);
            var studentDTO = mapper.Map<StudentDTO>(student);

            return Ok(studentDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(StudentDTO studentDTO)
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
                var student = mapper.Map<Student>(studentDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                student = await studentService.Insert(student);
                return Ok(studentDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Student studentDTO, int id) // object - cuerpo pero si es prmitivo por la url 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (studentDTO.ID != id)
                return BadRequest();

            var flag = await studentService.GetById(id);

            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                var student = mapper.Map<Student>(studentDTO);
                student = await studentService.Insert(student);
                return Ok(student); //Sastus code 200
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
            var flag = await studentService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                await studentService.Delete(id);
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