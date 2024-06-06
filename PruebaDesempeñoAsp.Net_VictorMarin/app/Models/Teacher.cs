using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace app.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? Speciality { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int YearsExperience { get; set; }

        [JsonIgnore]
        public List<Course>? Courses { get; set; }
    }
}