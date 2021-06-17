using System;
using System.Linq;
using System.Collections.Generic;
using CourseManager.Models;

namespace CourseManager.Repos
{
    public class InMemStudentRepo
    {
        public static List<Student> _allStudents = new List<Student>
        {
            new Student {Id = 1, Name = "A"},
            new Student {Id = 2, Name = "B"},
            new Student {Id = 3, Name = "C"},
            new Student {Id = 4, Name = "D"},
            new Student {Id = 5, Name = "E"},
            new Student {Id = 6, Name = "F"},
            new Student {Id = 7, Name = "G"},
        };


        public InMemStudentRepo()
        {
        }

        public List<Student> GetAll()
        {
            return _allStudents.Select(s => new Student(s)).ToList();
        }

        public Student GetById( int id)
        {
            return _allStudents.SingleOrDefault(s => s.Id == id);
        }
    }
}
