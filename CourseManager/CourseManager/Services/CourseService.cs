using System;
using System.Collections.Generic;
using CourseManager.Exceptions;
using CourseManager.Models;
using CourseManager.Repos;

namespace CourseManager.Services
{
    public class CourseService
    {
        InMemCourseRepo _courseRepo = new InMemCourseRepo();
        InMemTeacherRepo _teacherRepo = new InMemTeacherRepo();
        InMemStudentRepo _studentRepo = new InMemStudentRepo();

        public List<Course> GetAll()
        {
            return _courseRepo.GetAll();
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepo.GetAll();
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepo.GetAll();
        }

        public Course GetById(int id)
        {
            Course toReturn = _courseRepo.GetById(id);

            if( toReturn == null)
            {
                throw new CourseNotFoundException($"No course has an id of {id}.");
            }

            return toReturn;
        }


        public Teacher GetTeacherById(int id)
        {
            Teacher toReturn = _teacherRepo.GetById(id);

            if (toReturn == null)
            {
                throw new TeacherNotFoundException($"No teacher has an id of {id}.");
            }

            return toReturn;
        }

        public void EditCourse(Course toEdit)
        {
            _courseRepo.Edit(toEdit);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepo.GetById(id);
        }
    }
}
