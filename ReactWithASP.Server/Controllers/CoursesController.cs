//using Microsoft.AspNetCore.Mvc;
//using StudentCourseAPI.Repositories;
//using StudentCourseAPI.Models;

//namespace StudentCourseAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CoursesController : ControllerBase
//    {
//        private readonly CourseRepository _courseRepository;

//        public CoursesController(CourseRepository courseRepository)
//        {
//            _courseRepository = courseRepository;
//        }

//        [HttpGet]
//        public IEnumerable<Course> Get()
//        {

//            return _courseRepository.GetCourses();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Repositories;
using StudentCourseAPI.Models;
using System.Collections.Generic;
using System;

namespace StudentCourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseRepository _courseRepository;

        public CoursesController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            var courses = _courseRepository.GetCourses();
            Console.WriteLine($"Returned {courses.Count()} courses");
            return courses;
        }
    }
}
