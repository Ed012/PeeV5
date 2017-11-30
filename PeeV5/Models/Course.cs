using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }

        public int IdCycle { get; set; }  //FK debe ser igual que el PK del otro cs
        public Cycle Cycle { get; set; } //referencia de cs relacionado
    }
}