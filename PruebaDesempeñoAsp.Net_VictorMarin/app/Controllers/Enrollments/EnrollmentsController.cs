using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using app.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.Enrollments
{
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentsController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        [Route("api/enrollments")]
        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _enrollmentRepository.GetAll();
        }
        
        [HttpGet]
        [Route("api/enrollments/{id}")]
        public Enrollment GetEnrollmentById(int id)
        {
            return _enrollmentRepository.GetById(id);
        }

        [HttpGet("api/enrollments/list/{date}")]
        public ActionResult<IEnumerable<Enrollment>> GetListEnrollmentsByDate(DateTime date)
        {
            var result = _enrollmentRepository.GetListEnrollmentsByDate(DateOnly.FromDateTime(date));
            return Ok(new { message = $"En la fecha {date.ToString("yyyy-MM-dd")} se realizaron {result.Count()} matriculas.", matriculas = result});
        }

        [HttpGet("api/enrollments/list/student/{studentId}")]
        public ActionResult<IEnumerable<Enrollment>> GetListEnrollmentsByStudent(int studentId)
        {
            var result = _enrollmentRepository.GetListEnrollmentsByStudent(studentId);
            return Ok(new { message = $"El estudiante {studentId} se matriculó en {result.Count()} cursos.", cursos = result});
        }

    }
}