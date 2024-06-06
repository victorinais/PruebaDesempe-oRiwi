using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Students
{
    public class StudentUpdateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentUpdateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPut]
        [Route("api/students/update/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("El dato no puede ser nulo.");
            }

            var studentToUpdate = _studentRepository.GetById(id);

            if (studentToUpdate == null)
            {
                return NotFound("No se encontro el estudiante.");
            }

            studentToUpdate.Names = student.Names;
            studentToUpdate.BirthDate= student.BirthDate;
            studentToUpdate.Address= student.Address;
            studentToUpdate.Email= student.Email;

            _studentRepository.Update(studentToUpdate);
            return Ok(new { message = "El estudiante se ha actualizado correctamente."});
        }
    }
}