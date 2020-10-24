using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using StudentApplication.Models;
using StudentApplication.Services;

namespace StudentApplication.Controllers
{
    public class CourseController : ApiController
    {
        static readonly Course course = new Course();

        // GET: api/Course 
        [Route("api/course")]
        [HttpGet]
        public IHttpActionResult GetAllCourses()
        {
            var response= course.GetCourses();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
       
        [Route("api/course/getstudents/{id}")]
        [HttpGet]
        public IHttpActionResult GetStudents(int id)
        {
            var response= course.GetStudents(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        // PUT: api/Course/5
        
        [Route("api/course/poststudent")]
        [HttpPost]
        public void PostStudent(StudentInCourse st)
        {
            course.AddStudentOnCourse(st.Student_id, st.ID_kursa);
        }

        // POST: api/Course
        [Route("api/course/postcourse")]
        [HttpPost]
        public void PostCourse(Kurs kurs)
        {
             course.AddCourse(kurs.NazivKursa);
        }
    }
}
