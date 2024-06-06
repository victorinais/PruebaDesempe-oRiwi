using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Students
{
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("api/students")]
        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        [HttpGet]
        [Route("api/students/{id}")]
        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }
        
        [HttpGet("api/students/list/{date}")]
        public IEnumerable<Student> GetStudentsByBirthdate(DateOnly date)
        {
            return _studentRepository.GetStudentsByBirthdate(date);
        }
    }
}