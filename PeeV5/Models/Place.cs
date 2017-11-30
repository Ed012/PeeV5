using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeeV5.Models
{
    public class Place
    {
        [Key]
        public int IdPlace { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}