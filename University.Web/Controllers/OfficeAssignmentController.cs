//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Security.Cryptography.X509Certificates;
//using System.Threading.Tasks;
//using System.Web.Http;
//using University.BL.Data;
//using University.BL.Repositories.Implements;
//using University.BL.Services.Implements;
//using University.BL.DTOs;
//using University.BL.Models;

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
using University.Web;

namespace University.API.Controllers
{
    public class OfficeAssignmentController : ApiController
    {
        private IMapper mapper;
        private readonly OfficeAssignmentService officeAssignmentService = new OfficeAssignmentService(new OfficeAssignmentRepository(UniversityContext.Create()));

        public OfficeAssignmentController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var officeAssignment = await officeAssignmentService.GetAll();
            var officeAssignmentDTO = officeAssignment.Select(x => mapper.Map<OfficeAssignmentDTO>(x));

            return Ok(officeAssignmentDTO); // Status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var officeAssignment = await officeAssignmentService.GetById(id);
            var officeAssignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeAssignment);

            return Ok(officeAssignmentDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(OfficeAssignmentDTO officeAssignmentDTO)
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
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                officeAssignment = await officeAssignmentService.Insert(officeAssignment);
                return Ok(officeAssignmentDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(OfficeAssignmentDTO officeAssignmentDTO, int id)//objet -> body / primitivo -> url
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (officeAssignmentDTO.InstructorID != id)
                return BadRequest();
            var flag = await officeAssignmentService.GetById(id);
            if (flag == null)
                return NotFound(); //status code 404
            try
            {
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);
                officeAssignment = await officeAssignmentService.Update(officeAssignment);
                return Ok(officeAssignmentDTO);//status code 200
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);//status code 500
            }
        }



        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await officeAssignmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                await officeAssignmentService.Delete(id);
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