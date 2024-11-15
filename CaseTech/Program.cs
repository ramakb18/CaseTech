using CaseTech.Models;
using CaseTech.Services;

namespace CaseTech
{

   public class Program
    {
        static void Main()
        {
            // Create Teachers
            var teacher1 = new Teacher { Id = 1, Name = "Henrik V. Poulsen" };
            var teacher2 = new Teacher { Id = 2, Name = "Neils Olsen" };
            var teacher3 = new Teacher { Id = 3, Name = "Michael Gilbert Hansen" };
            var teacher4 = new Teacher { Id = 4, Name = "Nikolaj Bo Fredsoe" };
            var teacher5 = new Teacher { Id = 5, Name = "Peter Erik Bergmann" };
            var teacher6 = new Teacher { Id = 6, Name = "Peter Suni" };

            // Create Students
            var students = new List<Student>
        {
            new Student { Name = "Andreas Lorenzen", Age = 19 },
            new Student { Name = "Casper Clemmensen", Age = 22 },
            new Student { Name = "Daneil Bjerre Jensen", Age = 17 },
            new Student { Name = "Hjalte Meosgaard Leth", Age = 20 },
            new Student { Name = "Johan Milter JAckbson", Age = 18 },
            new Student { Name = "Louis Thomas Dao Pedersen", Age = 21 },
            new Student { Name = "Lukas Haugstad Frederiksen", Age = 19 },
            new Student { Name = "Marcus Wahlstorm", Age = 20 },
            new Student { Name = "Marcu Slot Rohr", Age = 22 },
            new Student { Name = "Mathias Altburg", Age = 23 },
            new Student { Name = "Patrick Gutierrez Fogelstorm", Age = 16 },
            new Student { Name = "Ramtin Akbari", Age = 18 },
            new Student { Name = "Sebastian Tolbol Nielsen", Age = 17 },
            new Student { Name = "Simon Heilbuth", Age = 20 },
            new Student { Name = "Thobias Scarter Hammerkvist", Age = 19 },
            new Student { Name = "Yosef Kassa", Age = 21 }
        };

            // Create Courses and assign to Teachers
            var course1 = new Course { Id = 1, Name = "Grundlæggende Programmering", Teacher = teacher1 };
            var course2 = new Course { Id = 2, Name = "OOP", Teacher = teacher1 };
            var course3 = new Course { Id = 3, Name = "Computer Teknologi", Teacher = teacher2 };
            var course4 = new Course { Id = 4, Name = "ServerSikkerhed", Teacher = teacher3 };
            var course5 = new Course { Id = 5, Name = "Databse Programmering ", Teacher = teacher4 };
            var course6 = new Course { Id = 6, Name = "Netwærk", Teacher = teacher5 };
            var course7 = new Course { Id = 7, Name = "CleintProgrammering", Teacher = teacher6 };

            // Assign courses to teachers
            teacher1.AddCourse(course1);
            teacher1.AddCourse(course2);
            teacher2.AddCourse(course3);
            teacher3.AddCourse(course4);
            teacher4.AddCourse(course5);
            teacher5.AddCourse(course6);
            teacher6.AddCourse(course7);

            // Enroll Students in Courses
            course1.EnrollStudent(students[0]);
            course1.EnrollStudent(students[1]);
            course1.EnrollStudent(students[2]);

            course2.EnrollStudent(students[3]);
            course2.EnrollStudent(students[4]);
            course2.EnrollStudent(students[5]);

            course3.EnrollStudent(students[6]);
            course3.EnrollStudent(students[7]);
            course3.EnrollStudent(students[8]);

            course4.EnrollStudent(students[9]);
            course4.EnrollStudent(students[10]);
            course4.EnrollStudent(students[11]);

            course5.EnrollStudent(students[12]);
            course5.EnrollStudent(students[13]);

            course6.EnrollStudent(students[14]);
            course6.EnrollStudent(students[15]);

            course7.EnrollStudent(students[0]);
            course7.EnrollStudent(students[1]);

            // Create Lists of Teachers, Students, and Courses
            var teachers = new List<Teacher> { teacher1, teacher2, teacher3, teacher4, teacher5, teacher6 };
            var courses = new List<Course> { course1, course2, course3, course4, course5, course6, course7 };

            // Initialize Search Engine
            var searchEngine = new SearchEngine(teachers, students, courses);

            // Main Menu
            while (true)
            {
                Console.WriteLine("Vælg søgningskriterie:\n1. Lærer\n2. Elev\n3. Fag");
                if (Enum.TryParse(Console.ReadLine(), out SearchCriteria criteria))
                    searchEngine.Search(criteria);
                else
                    Console.WriteLine("Ugyldigt valg.");

                Console.WriteLine("Vil du foretage en ny søgning? (ja/nej)");
                if (Console.ReadLine()?.ToLower() != "ja")
                    break;
            }
        }
    }
}
