using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Enrollments
{
    public class EnrollmentUpdateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentUpdateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPut]
        [Route("api/enrollments/update/{id}")]
        public IActionResult UpdateEnrollment(int id, [FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("El dato no puede ser nulo.");
            }

            var enrollmentToUpdate = _enrollmentRepository.GetById(id);

            if (enrollmentToUpdate == null)
            {
                return NotFound("No se encontro la matricula.");
            }

            enrollmentToUpdate.Date = enrollment.Date;
            enrollmentToUpdate.StudentId = enrollment.StudentId;
            enrollmentToUpdate.CourseId = enrollment.CourseId;
            enrollmentToUpdate.Status = enrollment.Status;

            _enrollmentRepository.Update(enrollmentToUpdate);
            return Ok(new { message = "La matricula se ha actualizado correctamente."});


        }
    }
}