using System;
namespace CourseManager.Models
{
    public class Teacher
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public Teacher() { }

        public Teacher( Teacher that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
        }
    }
}
