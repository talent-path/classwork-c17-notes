using System;
using System.Linq;
using System.Collections.Generic;
using CourseManager.Models;

namespace CourseManager.Repos
{
    public class InMemTeacherRepo
    {
        static List<Teacher> _allTeachers = new List<Teacher>
        {
            new Teacher{
                Id = 1,
                Name = "David",
                Courses = new List<Course>
                {
                    new Course { Id = 1, Name = "C#" }
                }
            },
            new Teacher{
                Id = 2,
                Name = "Bob",
                Courses = new List<Course>
                {
                    new Course { Id = 2, Name = "Java" }
                } },
            new Teacher{
                Id = 3,
                Name = "Alice",
                Courses = new List<Course>
                {
                    new Course { Id = 1, Name = "Python" }
                }
            }
        };

        public InMemTeacherRepo()
        {
        }

        public List<Teacher> GetAll()
        {
            return _allTeachers.Select(t => new Teacher(t)).ToList();
        }

        public Teacher GetById(int id)
        {
            return _allTeachers.SingleOrDefault(t => t.Id == id);
        }
    }
}
