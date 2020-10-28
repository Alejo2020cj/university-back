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
    public class InstructorController : ApiController
    {
        private IMapper mapper;
        private readonly InstructorService instructorService = new InstructorService(new InstructorRepository(UniversityContext.Create()));

        public InstructorController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var instructor = await instructorService.GetAll();
            var instructorDTO = instructor.Select(x => mapper.Map<InstructorDTO>(x));

            return Ok(instructorDTO); // Status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var instructor = await instructorService.GetById(id);
            var instructorDTO = mapper.Map<InstructorDTO>(instructor);

            return Ok(instructorDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(InstructorDTO instructorDTO)
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
                var instructor = mapper.Map<Instructor>(instructorDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                instructor = await instructorService.Insert(instructor);
                return Ok(instructorDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }


        //[HttpPut]
        //public async Task<IHttpActionResult> Put(InstructorDTO instructorDTO, int id) // object - cuerpo pero si es prmitivo por la url 
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState); // status code 400

        //    if (instructorDTO.ID != id)
        //        return BadRequest();

        //    var flag = await instructorService.GetById(id);

        //    if (flag == null)
        //        return NotFound(); // status code 404

        //    try
        //    {
        //        var instructor = mapper.Map<Instructor>(instructorDTO);
        //        instructor = await instructorService.Insert(instructor);
        //        return Ok(instructor); //Sastus code 200
        //        //return Ok(courseDTO); //Sastus code 200
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex); //Status code 500
        //    }
        //}



        [HttpPut]
        public async Task<IHttpActionResult> Put(InstructorDTO instructorDTO, int id)//objet -> body / primitivo -> url
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (instructorDTO.ID != id)
                return BadRequest();
            var flag = await instructorService.GetById(id);
            if (flag == null)
                return NotFound(); //status code 404
            try
            {
                var instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Update(instructor);
                return Ok(instructorDTO);//status code 200
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);//status code 500
            }
        }



        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await instructorService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                await instructorService.Delete(id);
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