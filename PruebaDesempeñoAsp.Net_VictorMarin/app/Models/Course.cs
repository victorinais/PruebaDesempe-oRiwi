using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace app.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public string? Schedule { get; set; }
        public string? Duration { get; set; }
        public int Capacity { get; set; }

        [JsonIgnore]
        public List<Enrollment>? Enrollments { get; set; }
    }
}