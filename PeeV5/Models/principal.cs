using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class Principal
    {
        [Key]
        public int IdPrincipal { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public int DNI { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string Job_tittle { get; set; }

        public int IdPlace { get; set; }  //FK debe ser igual que el PK del otro cs
        public Place Place { get; set; } //referencia de cs relacionado
    }
}