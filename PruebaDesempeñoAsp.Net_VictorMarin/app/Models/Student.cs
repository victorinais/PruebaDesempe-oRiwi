using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace app.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Enrollment>? Enrollments { get; set; }
    }
}