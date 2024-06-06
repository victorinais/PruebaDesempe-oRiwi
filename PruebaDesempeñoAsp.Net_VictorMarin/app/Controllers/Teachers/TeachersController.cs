using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Teachers
{
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        [Route("api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            return _teacherRepository.GetAll();
        }

        [HttpGet]
        [Route("api/teachers/{id}")]
        public Teacher GetTeacherById(int id)
        {
            return _teacherRepository.GetById(id);
        }
    }
}