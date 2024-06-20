using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Repositories;
using StudentCourseAPI.Models;

namespace StudentCourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        public StudentsController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            //var students = _studentRepository.GetStudents();

            //Console.WriteLine($"Returned {students.Count()} students");
            return _studentRepository.GetStudents();
        }
    }
}
