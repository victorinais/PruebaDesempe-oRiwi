using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Courses
{
    public class CourseCreateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseCreateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        [Route("api/courses/create")]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("El dato es nulo");
            }
            _courseRepository.Add(course);
            return Ok(new { message = "El curso se ha creado éxitosamente.", course = course});
        }
    }
}