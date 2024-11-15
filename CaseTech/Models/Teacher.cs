using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTech.Models
{
    public class Teacher : IComparable<Teacher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; } = new List<Course>();

        public void AddCourse(Course course) => Courses.Add(course);

        public int CompareTo(Teacher other) => string.Compare(this.Name, other.Name, StringComparison.Ordinal);
    }
}
