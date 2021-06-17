using System;
namespace CourseManager.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public Student() { }

        public Student(Student that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
        }
    }
}
