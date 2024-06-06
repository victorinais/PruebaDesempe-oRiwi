using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.Services.Enrollments
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(int id);
        IEnumerable<Enrollment> GetListEnrollmentsByDate(DateOnly date);
        IEnumerable<Enrollment> GetListEnrollmentsByStudent(int studentId);
    }
}