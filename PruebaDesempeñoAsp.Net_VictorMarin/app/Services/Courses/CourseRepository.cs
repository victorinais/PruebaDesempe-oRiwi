using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Services.Courses
{
    public class CourseRepository : ICourseRepository
    {
        public readonly BaseContext _context;
        public CourseRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            var courses = _context.Courses
                .Include(c => c.Teacher)
                .ToList();
            return courses!;
        }

        public Course GetById(int id)
        {
            var courses = _context.Courses
                .Include(c => c.Teacher)
                .FirstOrDefault(c => c.Id == id);
            return courses!;
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetCoursesByTeacher(int teacherId)
        {
            var courses = _context.Courses
               .Include(c => c.Teacher)
               .Where(c => c.TeacherId == teacherId)
               .ToList();
            return courses!;
        }
    }
}