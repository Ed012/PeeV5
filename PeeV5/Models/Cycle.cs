using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class Cycle
    {
        [Key]
        public int IdCycle { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Course> Courses { get; set; }

        public int IdTeacher { get; set; }  //FK debe ser igual que el PK del otro cs
        public Teacher Teacher { get; set; } //referencia de cs relacionado
    }
}