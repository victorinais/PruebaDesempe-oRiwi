using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Enrollments
{
    public class EnrollmentCreateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPost]
        [Route("api/enrollments/create")]
        public IActionResult CreateEnrollment([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("El dato es nulo");
            }
            _enrollmentRepository.Add(enrollment);
            return Ok(new { message = "La matricula se ha creado éxitosamente.", enrollment = enrollment});
        }
    }
}