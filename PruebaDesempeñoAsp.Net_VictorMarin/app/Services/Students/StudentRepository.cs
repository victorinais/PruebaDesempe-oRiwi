using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.Services.Students
{
    public class StudentRepository : IStudentRepository
    {
        public readonly BaseContext _context;
        public StudentRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            var students = _context.Students
               .ToList();
            return students!;
        }

        public Student GetById(int id)
        {
            var students = _context.Students
                .FirstOrDefault(s => s.Id == id);
            return students!;
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetStudentsByBirthdate(DateOnly date)
        {
            var students = _context.Students
               .Where(s => s.BirthDate == date)
               .ToList();
            return students!;
        }
        
    }
}