using CaseTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTech.Services
{
    public class SearchEngine
    {
        private readonly List<Teacher> _teachers;
        private readonly List<Student> _students;
        private readonly List<Course> _courses;

        public SearchEngine(List<Teacher> teachers, List<Student> students, List<Course> courses)
        {
            _teachers = teachers.OrderBy(t => t.Name).ToList();
            _students = students.OrderBy(s => s.Name).ToList();
            _courses = courses.OrderBy(c => c.Name).ToList();
        }

        public void Search(SearchCriteria criteria)
        {
            switch (criteria)
            {
                case SearchCriteria.Teacher:
                    SearchByTeacher();
                    break;
                case SearchCriteria.Student:
                    SearchByStudent();
                    break;
                case SearchCriteria.Course:
                    SearchByCourse();
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg.");
                    break;
            }
        }

        private void SearchByTeacher()
        {
            Console.WriteLine("Liste over lærere:");
            foreach (var teacher in _teachers)
                Console.WriteLine($"ID: {teacher.Id}, Navn: {teacher.Name}");

            Console.Write("Indtast lærerens ID: ");
            if (int.TryParse(Console.ReadLine(), out int teacherId))
            {
                var teacher = _teachers.FirstOrDefault(t => t.Id == teacherId);
                if (teacher != null)
                {
                    Console.WriteLine($"Lærer: {teacher.Name}");
                    foreach (var course in teacher.Courses)
                    {
                        Console.WriteLine($"Fag: {course.Name} - {course.Students.Count} elever");
                        foreach (var student in course.Students)
                            Console.WriteLine(student.Age < 20
                                ? $"  - \u001b[31m{student.Name} (Under 20)\u001b[0m"
                                : $"  - {student.Name}");
                    }
                }
                else
                    Console.WriteLine("Ingen match fundet.");
            }
            else
                Console.WriteLine("Ugyldigt input.");
        }

        private void SearchByStudent()
        {
            Console.Write("Indtast elevens fulde navn: ");
            var studentName = Console.ReadLine();

            var student = _students.FirstOrDefault(s => s.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                Console.WriteLine($"Elev: {student.Name}");
                foreach (var course in _courses.Where(c => c.Students.Contains(student)))
                    Console.WriteLine($"Fag: {course.Name} (Underviser: {course.Teacher.Name})");
            }
            else
                Console.WriteLine("Ingen match fundet.");
        }

        private void SearchByCourse()
        {
            Console.WriteLine("Liste over fag:");
            foreach (var course in _courses)
                Console.WriteLine($"ID: {course.Id}, Navn: {course.Name}");

            Console.Write("Indtast fagets ID: ");
            if (int.TryParse(Console.ReadLine(), out int courseId))
            {
                var course = _courses.FirstOrDefault(c => c.Id == courseId);
                if (course != null)
                {
                    Console.WriteLine($"Fag: {course.Name}");
                    Console.WriteLine($"Underviser: {course.Teacher.Name}");
                    Console.WriteLine($"Antal elever: {course.Students.Count}");
                    foreach (var student in course.Students)
                        Console.WriteLine(student.Age < 20
                            ? $"  - \u001b[31m{student.Name} (Under 20)\u001b[0m"
                            : $"  - {student.Name}");
                }
                else
                    Console.WriteLine("Ingen match fundet.");
            }
            else
                Console.WriteLine("Ugyldigt input.");
        }
    }
}
