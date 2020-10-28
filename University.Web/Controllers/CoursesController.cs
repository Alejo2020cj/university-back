using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;



namespace University.Web.Controllers
{

    //[Authorize]
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {


        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));
        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();



        }
        //[HttpPost] //insertar - create
        // [HttpGet]  //Consultas - Read      
        // [HttpPut]  //Modificar - Update
        // [HttpDelete] //Eliminar - Delete

        /// <summary>
        /// Obtiene los objetos de cursos
        /// </summary>
        /// <returns>Listado de los objetos de cursos</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitado.</response>

        [HttpGet]
        [ResponseType(typeof(IEquatable<CourseDTO>))]
        
        public async Task<IHttpActionResult> Get()
        {
            var courses = await courseService.GetAll();
           var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));


          return Ok(coursesDTO);//status code 200
      }
        /// <summary>
        /// Obtiene un objeto Course por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ///  /// <response code="200">OK. Devuelve el objetos solicitado.</response>
        /// <response code="400">OK. No se ha encontrado el objeto.</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var course = await courseService.GetById(id);
            var coursesDTO = mapper.Map<CourseDTO>(course);


            return Ok(coursesDTO);//status code 200
        }

        [HttpPost]

        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var course = mapper.Map<Course>(courseDTO);

                course = await courseService.Insert(course);
                return Ok(courseDTO);//status code 200
            }
            catch (Exception ex)

            {
                return InternalServerError(ex);//status code 500
            }


        }





        [HttpPut]

        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)//objet -> body / primitivo -> url
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (courseDTO.CourseID != id)
                return BadRequest();

            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound(); //status code 404

            try
            {
                var course = mapper.Map<Course>(courseDTO);

                course = await courseService.Update(course);
                return Ok(course);//status code 200
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);//status code 500
            }


        }



        [HttpDelete]

        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound(); //status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                //else
                    //throw new Exception("ForeinKeys");
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);//status code 500
            }
        }
    }
}
