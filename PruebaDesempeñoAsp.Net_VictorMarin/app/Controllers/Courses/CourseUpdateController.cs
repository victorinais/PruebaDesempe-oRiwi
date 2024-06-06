using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Courses
{
    public class CourseUpdateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseUpdateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPut]
        [Route("api/courses/update/{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("El dato no puede ser nulo.");
            }

            var courseToUpdate = _courseRepository.GetById(id);

            if (courseToUpdate == null)
            {
                return NotFound("No se encontro el curso.");
            }

            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;
            courseToUpdate.TeacherId = course.TeacherId;
            courseToUpdate.Schedule = course.Schedule;
            courseToUpdate.Duration = course.Duration;
            courseToUpdate.Capacity = course.Capacity;

            _courseRepository.Update(courseToUpdate);
            return Ok(new { message = "El curso se ha actualizado correctamente."});
        }
    }
}