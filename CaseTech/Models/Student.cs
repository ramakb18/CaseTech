using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTech.Models
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Student other) => string.Compare(this.Name, other.Name, StringComparison.Ordinal);
    }
}
