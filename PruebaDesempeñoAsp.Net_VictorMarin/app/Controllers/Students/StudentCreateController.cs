using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Students
{
    public class StudentCreateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentCreateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        [Route("api/students/create")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("El dato es nulo");
            }
            _studentRepository.Add(student);
            return Ok(new { message = "El estudiante se ha creado éxitosamente.", student = student});
        }
    }
}