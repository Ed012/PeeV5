using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public int IdPlace { get; set; }  //FK debe ser igual que el PK del otro cs
        public Place Place { get; set; } //referencia de cs relacionado

        public int IdCycle { get; set; }  //FK debe ser igual que el PK del otro cs
        public Cycle Cycle { get; set; } //referencia de cs relacionado
    }
}