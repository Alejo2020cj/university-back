using Newtonsoft.Json;
using System.Linq;
using System.Web.Http;
using University.BL.Data;
using University.BL.Models;


namespace University.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly UniversityContext universityContext = UniversityContext.Create();
        // GET api/values
        [HttpGet]
        public IHttpActionResult Get()
        {

          

            var courses = (from q in universityContext.Courses
                           select new
                           {
                             //q.CourseID,
                               q.Title,
                               q.Credits
                           }).ToList();

            //return Ok(courses);
            return Ok(JsonConvert.SerializeObject(courses));
        }
     

        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
        var course = (from q in universityContext.Courses
                      where q.CourseID == id
                      select new
                      {
                          q.CourseID,
                          q.Title,
                          q.Credits
                      }).ToList();
        //  return Ok(course);
            return Ok(JsonConvert.SerializeObject(course));
        }








        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
