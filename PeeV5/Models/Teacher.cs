using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        public string pass { get; set; }
        
        public int IdPrincipal { get; set; }  //FK debe ser igual que el PK del otro cs
        public Principal Principal { get; set; } //referencia de cs relacionado
    }
}