using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Teachers
{
    public class TeacherCreateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherCreateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPost]
        [Route("api/teachers/create")]
        public IActionResult CreateTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("El dato es nulo");
            }
            _teacherRepository.Add(teacher);
            return Ok(new { message = "El profesor se ha creado éxitosamente.", teacher = teacher});
        }
    }
}