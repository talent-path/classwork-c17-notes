using System;
using System.ComponentModel.DataAnnotations;

namespace RazorDemo.Models
{
    public class FakeModel
    {
        public int Id { get; set; }

        [Display(Name = "Fake Model Name")]
        public string Name { get; set; }
    }
}
