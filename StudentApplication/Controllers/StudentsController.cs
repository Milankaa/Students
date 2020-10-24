using StudentApplication.Models;
using StudentApplication.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace StudentApplication.Controllers
{
    public class StudentsController : ApiController
    {
        static readonly StudentRepos student = new StudentRepos();
        private readonly Test_dbEntities db = new Test_dbEntities();

        // GET: api/Students
        [Route("api/students")]
        [HttpGet]
        public List<Student> GetAllStudents()
        {
             return student.GetStudents();    
        }
        [Route("api/students/{id}")]
        [HttpGet]
        public Student GetStudent(int id)
        {
            var response = student.GetStudent(id);
            return response;
            
        }
       
        // PUT: api/Students/5
        [Route("api/students")]
        [HttpPut]
        public string PutStudent(Student s)
        {
            var response = student.UpdateStudent(s);
            return response;
        }
        [Route("api/students")]
        [HttpPost]
        // POST: api/Student
        public string PostStudent(Student s)
        {
            var response = student.AddStudent(s);
            return response;
        }

        // DELETE: api/Students/5
        [Route("api/students/{id}")]
        [HttpDelete]
        public string DeleteStudent(int id)
        {
            var response = student.DeleteStudent(id);
            return response;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
