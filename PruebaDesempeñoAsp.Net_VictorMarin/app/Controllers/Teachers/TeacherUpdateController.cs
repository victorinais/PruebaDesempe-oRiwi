using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Services.Teachers
{
    public class TeacherUpdateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherUpdateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPut]
        [Route("api/teachers/update/{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("El dato no puede ser nulo.");
            }

            var teacherToUpdate = _teacherRepository.GetById(id);

            if (teacherToUpdate == null)
            {
                return NotFound("No se encontro el profesor.");
            }

            teacherToUpdate.Names = teacher.Names;
            teacherToUpdate.Speciality= teacher.Speciality;
            teacherToUpdate.Phone= teacher.Phone;
            teacherToUpdate.Email= teacher.Email;
            teacherToUpdate.YearsExperience= teacher.YearsExperience;

            _teacherRepository.Update(teacherToUpdate);
            return Ok(new { message = "El profesor se ha actualizado correctamente."});
        }
    }
}