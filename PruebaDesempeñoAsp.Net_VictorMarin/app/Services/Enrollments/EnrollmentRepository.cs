using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Services.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public readonly BaseContext _context;
        public EnrollmentRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enrollment> GetAll()
        {
            var enrollment = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Status == "Activo" || e.Status == "Inactivo")
                .ToList();
            return enrollment!;  
        }

        public Enrollment GetById(int id)
        {
            var enrollment = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Status == "Activo" || e.Status == "Inactivo")
                .FirstOrDefault(e => e.Id == id);
            return enrollment!;
        }

        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        public IEnumerable<Enrollment> GetListEnrollmentsByDate(DateOnly date)
        {
            var enrollment = _context.Enrollments
               .Include(e => e.Student)
               .Include(e => e.Course)
               .Where(e => e.Status == "Activo" || e.Status == "Inactivo")
               .Where(e => e.Date == date)
               .ToList();
            return enrollment!;
        }

        public IEnumerable<Enrollment> GetListEnrollmentsByStudent(int studentId)
        {
            var enrollment = _context.Enrollments
               .Include(e => e.Student)
               .Include(e => e.Course)
               .Where(e => e.Status == "Activo" || e.Status == "Inactivo")
               .Where(e => e.StudentId == studentId)
               .ToList();
            return enrollment!;
        }
    }
}