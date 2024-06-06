using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.Services.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        public readonly BaseContext _context;
        public TeacherRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAll()
        {
            var teacher = _context.Teachers
                .ToList();
            return teacher!;
        }

        public Teacher GetById(int id)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == id);
            return teacher!;
        }

        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
    }
}