using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataCore3.Models;
using System.Collections.Generic;
using System.Linq;

namespace ODataCore3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Student student;
        //StudentDBContext _context;
        public StudentsController()
        {
            //_context = new StudentDBContext();
        }
        // GET: api/Student
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Student> Get()
        {
            #region version_1
            //return new List<Student>
            //{
            //new Student
            //{
            //    StudentId = 1,
            //    StudentName = "Ramazan",
            //    StudentScore = 51,
            //    StudentAge = 23
            //},
            //new Student
            //{
            //    StudentId = 2,
            //    StudentName = "Harun",
            //    StudentScore = 95,
            //    StudentAge = 32
            //},
            //new Student
            //{
            //    StudentId = 3,
            //    StudentName = "Mümin",
            //    StudentScore = 85,
            //    StudentAge = 26
            //}
            //};
            #endregion

            #region version_2
            using (var _context = new StudentDBContext())
            {
                //Student student = new Student();

                //student.StudentId = 4; PrimaryKey olduğu için elimizle vermiyoruz
                //student.StudentAge = 30;
                //student.StudentName = "Veli";
                //student.StudentScore = 20;

                //_context.Students.Add(student);
                //_context.SaveChanges();
                return _context.Students.ToList();
            }
            #endregion
        }

        [HttpGet("{id}")]
        [EnableQuery()]
        public Student Get(int id)
        {
            using (var _context = new StudentDBContext())
            {
                return _context.Students.Find(id);
            }
        }
    

        [HttpDelete("{id}")]
        [EnableQuery()]
        public void Delete(int id)
        {
            using (var _context = new StudentDBContext())
            {
                _context.Students.Remove(_context.Students.Find(id));
                _context.SaveChanges();
            }
        }

        [HttpPost]
        [EnableQuery()]
        public void Post(Student student)
        {
            using (var _context = new StudentDBContext())
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
        }
    }
}
