using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Courses
{
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("api/courses")]
        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        [HttpGet]
        [Route("api/Courses/{id}")]
        public Course GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }

        [HttpGet("api/courses/list/{teacherId}")]
        public IEnumerable<Course> GetCoursesByTeacher(int teacherId)
        {
            var data =  _courseRepository.GetCoursesByTeacher(teacherId);
            return data;
        }
    }
}